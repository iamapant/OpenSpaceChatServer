using Api.DAL;

namespace Api.Providers.Email;

public class SmtpEmailProvider : IEmailProvider {
    private EmailSettings _settings;
    public SmtpEmailProvider(GlobalSettings globalSettings) { _settings = globalSettings.Email; }
    public async Task<ValidationResult> Send(IEmailTemplate template) {
        throw new NotImplementedException();
    }
}