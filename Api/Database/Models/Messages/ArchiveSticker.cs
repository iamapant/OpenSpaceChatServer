using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Database.Models;

public class ArchiveSticker {
    [ForeignKey(nameof(Archive))]
    public string ArchiveId { get; set; } = null!;
    [ForeignKey(nameof(StickerUrl))]
    public Guid StickerUrlId { get; set; }
    [ForeignKey(nameof(StickerStyle))]
    public Guid StickerStyleId  { get; set; }

    public Message Archive { get; set; } = null!;
    public StickerStyle StickerStyle { get; set; } = null!;
    public StickerUrl StickerUrl { get; set; } = null!;
}

public class ArchiveStickerModelCreation : IModelCreationSettings<ArchiveSticker> {
    public void OnModelCreating(EntityTypeBuilder<ArchiveSticker> builder, ModelBuilder mb) {
        builder.HasKey(e => new { MessageId = e.ArchiveId, e.StickerUrlId, e.StickerStyleId });
    }
}