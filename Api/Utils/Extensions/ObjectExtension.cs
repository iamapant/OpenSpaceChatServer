using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Api;

public static class ObjectExtension {
    public static ReflectionHelper Reflect(this object? obj) => new (obj);
    
    public static string[] Name(this PropertyInfo[] props) => props.Select(p => p.Name).ToArray();
    public static string[] Name(this FieldInfo[] fields) => fields.Select(p => p.Name).ToArray();
    
}

public class ReflectionHelper(object? obj) {
    private Type? _type = obj?.GetType() ?? null;
    public bool HasValue = obj != null;
    
    public PropertyInfo[] Properties() {
        if (_type == null) return [];

        return _type.GetProperties();
    }
    public T? Property<T>(string name, bool fullMatch = true) {
        if (_type == null) return default;

        if (!fullMatch) {
            var match = Properties()
                .FirstOrDefault(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase));

            if (match == null) return default;
            
            return (T?)match.GetValue(_type);
        }
        
        return (T?)_type.GetProperty(name)?.GetValue(obj);
    }

    public bool TryGetProperty<T>(string name,[MaybeNullWhen(false)] out T value, bool fullMatch = true) {
        value = Property<T>(name, fullMatch) ?? default;
        return value != null;
    }

    public FieldInfo[] Fields() {
        if (_type == null) return [];

        return _type.GetFields();
    }
    public T? Field<T>(string name, bool fullMatch = true) {
        if (_type == null) return default;
        
        if (!fullMatch) {
            var match = Fields()
                .FirstOrDefault(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase));

            if (match == null) return default;
            
            return (T?)match.GetValue(_type);
        }
        return (T?)_type.GetField(name)?.GetValue(obj);
    }

    public bool TryGetField<T>(string name,[MaybeNullWhen(false)] out T value, bool fullMatch = true) {
        value = Field<T>(name) ?? default;
        return value != null;
    }
}