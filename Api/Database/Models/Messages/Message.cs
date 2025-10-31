using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Database.Models;

public abstract class Message {
    [Key, MaxLength(100)]
    public string Id { get; set; } = null!;

    [Required, MaxLength(20)]
    public string? ContentType { get; set; }
    [MaxLength(500)]
    public string? Content { get; set; }
    
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

    public ICollection<MessageReaction> Reactions { get; set; } = new List<MessageReaction>();
    
    public string GetId() {
        return $"{User?.Id.ToString()??"0"}_{Position.Latitude}.{Position.Longitude}_{Guid.CreateVersion7().ToString()}";
    }
}