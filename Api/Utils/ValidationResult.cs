using System.Collections.ObjectModel;

namespace Api;

public class ValidationResult {
    public ValidationResult() { }

    public ValidationResult(params List<ValidationError> errors) { _errors = errors; }

    public ValidationResult(string code, string message, object? source = null) {
        _errors = [new(code, message, source)];
    }
    
    public ValidationResult(Exception ex, object? source = null) : this(ex.GetType().Name, ex.Message, source) { }
    
    public bool IsValid => _errors.Count == 0;
    public ReadOnlyCollection<ValidationError> Errors => _errors.AsReadOnly();
    private List<ValidationError> _errors = new ();
    public void AddError(ValidationError error) => _errors.Add(error);
    public void AddError(params ValidationError[] error) => _errors.AddRange(error);
    public void AddError(string code, string message, object? source = null)
        => AddError(new ValidationError(code, message, source));
    
    public static implicit operator bool(ValidationResult val) => val.IsValid;

    public static ValidationResult operator +
        (ValidationResult val, ValidationError e) {
        val.AddError(e);
        return val;
    }
    public static ValidationResult operator +
        (ValidationResult a, ValidationResult b) {
        var ret = new ValidationResult();
        ret._errors = new List<ValidationError>(a._errors.Concat(b._errors));
        return ret;
    }
}
public record class ValidationError(string Code, string Message, object? Source = null);