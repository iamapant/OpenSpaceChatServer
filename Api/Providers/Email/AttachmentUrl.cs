namespace Api.Providers.Email;

public record struct AttachmentUrl(AttachmentSource Source, string Url) {
    public byte[] GetAttachment() {
        throw new NotImplementedException();
        switch (Source) {
            case AttachmentSource.File:
                
                break;
            case AttachmentSource.Cloudflare:
                break;
            case AttachmentSource.Amazon:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}

public enum AttachmentSource {
    File
  , Cloudflare
  , Amazon
}