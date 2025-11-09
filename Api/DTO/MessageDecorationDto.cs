namespace Api.DTO;

public class MessageDecorationDto {
    public Guid FrameId { get; set; }
    public Guid FrameOptionsId { get; set; }
    public Guid FontFamilyId { get; set; }
    public Guid FontStyleId { get; set; }
    public List<(Guid Url, Guid Style)> Stickers { get; set; } = new();
}