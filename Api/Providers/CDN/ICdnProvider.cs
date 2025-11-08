namespace Api.Providers.CDN;

public interface ICdnProvider {
    Task<ValidationResult> Upload(CdnUpload dto);
    Task<ValidationResult> Delete(string url);
    Task<ValidationResult> Get(string url);
}