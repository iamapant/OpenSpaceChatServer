using System.ComponentModel.DataAnnotations;

namespace Api.DTO;

public class MessageFrameDto{
    [Required]
    public string FrameId { get; set; } = null!;
    public int? PrimaryColorArgb { get; set; }
    public int? SecondaryColorArgb { get; set; }
}