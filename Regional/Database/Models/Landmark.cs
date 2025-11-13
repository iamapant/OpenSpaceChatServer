using System.ComponentModel.DataAnnotations;
using Api;

namespace Regional.Database.Models;

public class Landmark {
    [Key]
    public Guid Id { get; set; }

    [Required, MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    [Required, MaxLength(2048)]
    public string IconUrl { get; set; } = string.Empty;
    [MaxLength(300)]
    public string? Description { get; set; }
    [MaxLength(2048)]
    public string? PhotoUrl { get; set; }
    [MaxLength(2048)]
    public string? InfoUrl { get; set; }
    [Required]
    public double Latitude { get; set; }
    [Required]
    public double Longitude { get; set; }
    public Position Position => new (Latitude, Longitude);
    public ICollection<Message> Messages { get; set; } = new List<Message>();
}