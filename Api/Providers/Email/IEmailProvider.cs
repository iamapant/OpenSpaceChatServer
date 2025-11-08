namespace Api.Providers.Email;

public interface IEmailProvider {
    Task<ValidationResult> Send(IEmailTemplate template);
}