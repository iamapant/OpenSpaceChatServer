namespace Api.Providers.Email;

public interface IEmailTemplate {
    public string Subject { get; }
    public string BodyHtml { get; }
    public string[] Recipients { get; }
    public string[]? CcRecipients { get; }
    public string[]? BccRecipients { get; }
    public AttachmentUrl[]? Attachments { get; }
}