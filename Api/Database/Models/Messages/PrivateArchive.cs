using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Database.Models;

[Table("PrivateArchives")]
public class PrivateArchive : PrivateMessage {
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
    
    public MessageDecoration? Decoration { get; set; }
    
    public ICollection<ArchiveSticker> ArchivedStickers { get; set; } = new List<ArchiveSticker>();
    // public ICollection<StickerStyle>? Stickers { get; set; }
    // public ICollection<StickerUrl>? StickerUrls { get; set; }
}

public class PrivateArchiveModelCreation : IModelCreationSettings<PrivateArchive> {
    public void OnModelCreating(EntityTypeBuilder<PrivateArchive> builder, ModelBuilder mb) {
        builder.Property(e => e.IsPublic).HasDefaultValue(false);
    }
}