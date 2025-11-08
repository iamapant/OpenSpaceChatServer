using System.Collections.ObjectModel;

namespace Api;

public class ValidationResult {
    public ValidationResult(object? source = null) { _defaultSource = source; }

    private object? _defaultSource = null;

    public ValidationResult(params List<ValidationError> errors) { _errors = errors; }

    public ValidationResult(string code
      , string message
      , object? source = null) {
        _errors = [new(code, message, source)];
        _defaultSource = source;
    }

    public ValidationResult(Exception ex, object? source = null) :
        this(ex.GetType().Name, ex.Message, source) { }

    public virtual bool IsValid => _errors.Count == 0;
    public ReadOnlyCollection<ValidationError> Errors => _errors.AsReadOnly();
    protected List<ValidationError> _errors = new();
    public void AddError(ValidationError error) => _errors.Add(error);

    public void AddError(Exception exception, object? source = null) =>
        AddError(exception.GetType().Name, exception.Message, source);

    public void AddError(params ValidationError[] error) =>
        _errors.AddRange(error);

    public void AddError(string code, string message, object? source = null)
        => AddError(new ValidationError(code, message, source ?? _defaultSource));

    public static implicit operator bool(ValidationResult val) => val.IsValid;

    public static ValidationResult operator +(ValidationResult val
      , ValidationError e) {
        val.AddError(e);
        return val;
    }

    public static ValidationResult operator +(ValidationResult a
      , ValidationResult b) {
        var ret = new ValidationResult();
        ret._errors = new List<ValidationError>(a._errors.Concat(b._errors));
        return ret;
    }
}

public record class ValidationError(string Code, string Message, object? Source = null);

public static class ValidationResultExtensions {
    

    public static T ThrowIfInvalid<T>(this T val) where T : ValidationResult {
        if (val.IsValid) return val;
        throw new Exception($"{string.Join("\n", val.Errors
            .Select(e =>
                $"{e.Code}{(e.Source != null ? $"({e.Source})" : "")}: {e.Message}"))}");
    }
}

/////////////////////////////////////////////////
public class ValidationResult<T> : ValidationResult where T : notnull {
    public ValidationResult(T? value) : base() { Value = value; }

    public ValidationResult(params List<ValidationError> errors) :
        base(errors) { }

    public ValidationResult(string code, string message, object? source = null)
        : base(code, message, source) { }

    public ValidationResult(Exception ex, object? source = null) :
        base(ex.GetType().Name, ex.Message, source) { }

    public static ValidationResult<T> operator +(ValidationResult<T> a
      , ValidationResult b) {
        return new ValidationResult<T>(a._errors.Concat(b.Errors).ToList());
    }

    public T? Value { get; set; }
    public bool HasValue => Value != null;
    public override bool IsValid => base.IsValid && HasValue;
}