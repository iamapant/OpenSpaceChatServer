using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Api;

namespace Regional.Database.Models;

[Table("Messages")]
public class Message {
    public string Id { get; set; } = null!;
    
    [Required]
    public Guid? InboxId { get; set; }            //null for public messages
    public Inbox? Inbox { get; set; }
    [Required, MaxLength(20)]
    public string? ContentType { get; set; }
    [MaxLength(500)]
    public string? Content { get; set; }
    public DateTime Created { get; set; }
    public Guid? UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public User? User { get; set; } 
    
    [Required]
    public double Latitude { get; set; }
    [Required]
    public double Longitude { get; set; }
    public Position Position => new (Latitude, Longitude);
    
    public Guid? LandmarkId { get; set; }
    [ForeignKey(nameof(LandmarkId))]
    public Landmark? Landmark { get; set; }
    
    public MessageDecoration Decoration { get; set; } = null!;
    

    public static string GetIdPrivate(string userId, string inboxId) {
        return $"{userId}.{inboxId}.{DateTime.UtcNow}.{Guid.CreateVersion7().ToString()}";
    }
    public static string GetIdPublic(string userId, Position position) {
        return $"{userId}.{position.Latitude}.{position.Longitude}.{DateTime.UtcNow}.{Guid.CreateVersion7().ToString()}";
    }
}