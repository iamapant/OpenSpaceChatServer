using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Database.Models;

[Table("PrivateArchives")]
public class PrivateArchive : PrivateMessage, IArchive {
    [ForeignKey(nameof(ArchivedUser))]
    public Guid ArchivedUserId { get; set; }

    /// <summary>
    /// The user who archive the message
    /// </summary>
    public User ArchivedUser { get; set; } = null!;
    /// <summary>
    /// Saved private messages can be published to user's wall
    /// </summary>
    public bool IsPublic { get; set; }

    
    [MaxLength(500)]
    public string? Note { get; set; }
    
    [ForeignKey(nameof(Frame))]
    public Guid? FrameId { get; set; }
    public MessageFrame? Frame { get; set; }

    [ForeignKey(nameof(FrameOptions))]
    public Guid? FrameOptionsId { get; set; }
    public MessageFrameOptions? FrameOptions { get; set; }
    
    [ForeignKey(nameof(NoteFontStyle))]
    public Guid? NoteFontStyleId { get; set; }
    public FontStyle? NoteFontStyle { get; set; }
    
    [ForeignKey(nameof(NoteFontFamily))]
    public Guid? NoteFontFamilyId { get; set; }
    public FontFamily? NoteFontFamily { get; set; }
    
    public ICollection<MessageStickerStyle>? Stickers { get; set; }
}

public class PrivateArchiveModelCreation : IModelCreationSettings<PrivateArchive> {
    public void OnModelCreating(EntityTypeBuilder<PrivateArchive> builder, ModelBuilder mb) {
        builder.Property(e => e.IsPublic).HasDefaultValue(false);
    }
}