using System.ComponentModel.DataAnnotations;

namespace Regional.DTO;

public class RelayDto {
    [Required]
    public Guid RelayUserId { get; set; }

    [Required]
    public string ActionData { get; set; } = null!;
    
    [Required]
    public string RelayMessage { get; set; } = null!;
}