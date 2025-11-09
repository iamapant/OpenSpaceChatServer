using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Database.Models;

[Table("Reactions")]
public class Reaction {
    [ForeignKey(nameof(Message)), MaxLength(100)]
    public string MessageId { get; set; } = string.Empty;
    [ForeignKey(nameof(User))]
    public Guid UserId { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime Created { get; set; }
    [Required, MaxLength(10)]
    public string ReactionType { get; set; } = string.Empty;
    
    public Message Message { get; set; } = null!; 
    public User User { get; set; } = null!;
}

public class ReactionModelCreation : IModelCreationSettings<Reaction> {
    public void OnModelCreating(EntityTypeBuilder<Reaction> builder, ModelBuilder mb) {
        builder.HasKey(e => new { e.MessageId, e.UserId });
    }
}