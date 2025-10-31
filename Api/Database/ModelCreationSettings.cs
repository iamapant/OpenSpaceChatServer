using System.Drawing;
using System.Linq.Expressions;
using Api.Database.Models;
using Api.Hashing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Api.Database;

public static class ModelCreationValueConverter {
    public static ValueConverter<Color, int> ColorConverter = new (v => v.ToArgb(), v => Color.FromArgb(v));
    public static ValueConverter<TimeSpan, long>  TimeSpanConverter = new (v => v.Ticks, v => TimeSpan.FromTicks(v));
}

public interface IModelCreationSettings<T> where T : class {
    void OnModelCreating(EntityTypeBuilder<T> builder, ModelBuilder mb);
}

public static class ModelCreationRepository {
    private static Dictionary<Type, Type> _dict = new() {
        [typeof(Channel)] = typeof(ChannelModelCreation),
        [typeof(ChannelSetting)] = typeof(ChannelSettingModelCreation),
        [typeof(FontFamily)] = typeof(FontFamilyModelCreation),
        [typeof(FontStyle)] = typeof(FontStyleModelCreation),
        [typeof(Inbox)] = typeof(InboxModelCreation),
        [typeof(Landmark)] = typeof(LandmarkModelCreation),
        [typeof(Role)] = typeof(RoleModelCreation),
        [typeof(User)] = typeof(UserModelCreation),
        [typeof(UserTimeout)] = typeof(UserTimeoutModelCreation),
        [typeof(MessageFrameOptions)] = typeof(MessageFrameOptionsModelCreation),
        [typeof(MessageReaction)] = typeof(MessageReactionModelCreation),
        [typeof(PrivateMessage)] = typeof(PrivateMessageModelCreation),
        [typeof(PrivateArchive)] = typeof(PrivateArchiveModelCreation),
        [typeof(PublicArchive)] = typeof(PublicArchiveModelCreation),
        [typeof(MessageStickerStyle)] = typeof(MessageStickerStyleModelCreation),
        [typeof(SupportTicket)] = typeof(SupportTicketModelCreation),
        [typeof(UserBlacklist)] = typeof(UserBlacklistModelCreation),
        [typeof(CuratorSettings)] = typeof(CuratorSettingsCreationModel),
        [typeof(SupportTicketData)] = typeof(SupportTicketDataModelCreation),
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

    public static void SeedUser(ModelBuilder modelBuilder) {
        
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
            .AddEnvironmentVariables()
            .Build();
        var adminConfig = config.GetSection("Admin");
        
        var adminUsername = adminConfig.GetValue<string>("Username");
        var adminPassword = adminConfig.GetValue<string>("Password");
        var adminEmail = adminConfig.GetValue<string>("Email");
        if (adminUsername == null || adminPassword == null || adminEmail == null) {
            var nulledData = string.Empty;
            nulledData += adminUsername == null ? nameof(User.Name) : "";
            nulledData += (nulledData.Length > 0 ? ", " : "") + (adminPassword == null ? "Password" : "");
            nulledData += (nulledData.Length > 0 ? ", " : "") + (adminEmail == null ? nameof(UserInfo.Email) : "");
            
            throw new Exception($"Seed data must not be null: {nulledData}");
        }
        
        var adminRole = new Role { Id = Guid.Parse("019a3685-bab8-7dc4-ac85-8d0bb0d63218"), Name = "Admin" };
        var curatorRole = new Role { Id = Guid.Parse("019a3686-1b37-7087-9600-399694d0e4a1"), Name = "Curator" };
        var userRole = new Role { Id = Guid.Parse("019a3686-49f2-71d6-97bd-a2bb8e42da8e"), Name = "User" };
        
        var admin = new User { Id = Guid.Parse("019a3686-7e19-75d0-bf65-96f0f919394e"), Name = "Admin", PasswordHash = "$argon2id$v=19$m=65536,t=3,p=1$eI12WvnpYPXzPf4AG5Bsfg$fZLnznwn3EsME9EM1MG/N5ktw61J8adMYcH8JY9+gUg", Created = new DateTime(1,1,1,1,1,1,DateTimeKind.Utc), IsActive = true, RoleId = adminRole.Id };
        var adminInfo = new UserInfo { Id = admin.Id, Email = adminEmail, FirstName = adminUsername, DoB = new DateTime(2000, 1, 1, 0 ,0 ,0 , DateTimeKind.Utc), Updated = new DateTime(1,1,1,1,1,1,DateTimeKind.Utc)};
        
        modelBuilder.Entity<Role>().HasData(adminRole, curatorRole, userRole);
        modelBuilder.Entity<User>().HasData(admin);
        modelBuilder.Entity<UserInfo>().HasData(adminInfo);
    }
}