using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Database.Models;

[Table("PrivateMessages")]
public class PrivateMessage : Message {
    public Guid InboxId { get; set; }
    [ForeignKey(nameof(InboxId))]
    public Inbox Inbox { get; set; } = null!;
    public Guid PinnedDmId { get; set; }
    [ForeignKey(nameof(PinnedDm))]
    public Inbox PinnedDm { get; set; } = null!;
}

public class PrivateMessageModelCreation : IModelCreationSettings<PrivateMessage> {
    public void OnModelCreating(EntityTypeBuilder<PrivateMessage> builder, ModelBuilder mb) {
        builder.HasOne(e => e.PinnedDm).WithOne(e => e.PinnedMessage).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(e => e.Inbox).WithMany(e => e.Messages).OnDelete(DeleteBehavior.Cascade);
    }
}