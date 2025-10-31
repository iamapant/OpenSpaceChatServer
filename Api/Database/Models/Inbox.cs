using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Api.Database.Models;

[Table("Inboxes")]
public class Inbox {
    [Key]
    public Guid Id { get; set; }
    [Required, MaxLength(150)]
    public string Name { get; set; } = null!;
    
    [ForeignKey(nameof(PinnedMessage)), MaxLength(100)]
    public string? PinnedMessageId { get; set; }
    public PrivateMessage? PinnedMessage { get; set; }

    public ICollection<PrivateMessage> Messages { get; set; } = new List<PrivateMessage>();
    // public ICollection<PrivateArchive> Archives { get; set; } = new List<PrivateArchive>();
    public ICollection<User> Users { get; set; } = new List<User>();
}
public class InboxModelCreation : IModelCreationSettings<Inbox> {
    public void OnModelCreating(EntityTypeBuilder<Inbox> builder, ModelBuilder mb) {
        builder.Property(e => e.Id).HasValueGenerator<SequentialGuidValueGenerator>().ValueGeneratedOnAdd();
        builder.HasOne(e => e.PinnedMessage).WithOne(e => e.PinnedDm).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(e => e.Messages).WithOne(e => e.Inbox).OnDelete(DeleteBehavior.Cascade);
    }
}