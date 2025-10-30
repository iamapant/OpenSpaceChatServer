using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Database.Models;

[Table("PrivateMessages")]
public class PrivateMessage : Message {
    /// <summary>
    /// Only 1 message in the chat can be pinned at a time
    /// </summary>
    public bool IsPinned { get; set; }
    public Guid? DmId { get; set; }
    [ForeignKey(nameof(DmId))]
    public Channel? Dm { get; set; }
}

public class PrivateMessageModelCreation : IModelCreationSettings<PrivateMessage> {
    public void OnModelCreating(EntityTypeBuilder<PrivateMessage> builder, ModelBuilder mb) {
        builder.Property(e => e.IsPinned).HasDefaultValue(false);
    }
}