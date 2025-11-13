using System.Drawing;
using System.Reflection;
using Api;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Regional.Database;

public static class ModelCreationValueConverter {
    public static ValueConverter<Color, int> ColorConverter = new (v => v.ToArgb(), v => Color.FromArgb(v));
    public static ValueConverter<TimeSpan, long>  TimeSpanConverter = new (v => v.Ticks, v => TimeSpan.FromTicks(v));
}

public interface IModelCreationSettings<T> where T : class {
    void OnModelCreating(EntityTypeBuilder<T> builder, ModelBuilder mb);
}

public static class ModelCreationRepository {
    private static Dictionary<Type, Type> _dict = new() {
    };

    public static void AddModelCreationFor<TTable, TModelCreation>()
        where TTable : class
        where TModelCreation : IModelCreationSettings<TTable> {
        var typeA = typeof(TTable);
        var typeB = typeof(TModelCreation);
        _dict[typeA] = typeB;
    }

    public static ValidationResult ApplyAll(ModelBuilder modelBuilder) {
        var results = new ValidationResult();
        try {
            var repo = typeof(ModelCreationRepository);
            var applyMethod = repo.GetMethod(nameof(Apply));
            if (applyMethod == null) throw new Exception($"Cannot create {nameof(Apply)} method");
            
            foreach (var type in _dict.Keys) {
                var concreteMethod = applyMethod.MakeGenericMethod(type);
                var res = concreteMethod.Invoke(null, new object[] { modelBuilder });
                if (res is not ValidationResult r) results.AddError(type.Name, $"Cannot invoke {nameof(Apply)} method for type {type.Name}");
                else results += r;
            }
        }
        catch (Exception ex) {
            results.AddError(nameof(ApplyAll), ex.Message);
        }
        return results;
    }

    public static ValidationResult Apply<T>(ModelBuilder builder) where T : class {
        var result = new ValidationResult();
        try {
            if (!_dict.TryGetValue(typeof(T), out var type)) throw new Exception("Cannot find model type for type: " + typeof(T).Name);
            if (!type.IsAssignableTo(typeof(IModelCreationSettings<T>))) throw new Exception($"Model type {type.Name} is not assignable to IModelCreationSettings<{typeof(T).Name}>");
            var settings = (IModelCreationSettings<T>?)Activator.CreateInstance(type);
            if (settings == null) throw new Exception("Failed to create model settings of type " +  type.Name);

            settings.OnModelCreating(builder.Entity<T>(), builder);
        }
        catch (Exception ex) {
            result.AddError(typeof(T).Name, ex.Message);
        }

        return result;
    }
}