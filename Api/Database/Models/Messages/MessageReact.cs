using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Database.Models;

[Table("MessageReacts")]
public class MessageReaction {
    [ForeignKey(nameof(Message)), MaxLength(100)]
    public string MessageId { get; set; } = string.Empty;
    [ForeignKey(nameof(User))]
    public Guid UserId { get; set; }
    
    [Required, MaxLength(10)]
    public string Reaction { get; set; } = string.Empty;
    
    public Message Message { get; set; } = null!; 
    public User User { get; set; } = null!;
}

public class MessageReactionModelCreation : IModelCreationSettings<MessageReaction> {
    public void OnModelCreating(EntityTypeBuilder<MessageReaction> builder, ModelBuilder mb) {
        builder.HasKey(e => new { e.MessageId, e.UserId });
    }
}