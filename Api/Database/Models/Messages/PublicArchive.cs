using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Database.Models;

[Table("PublicArchives")]
public class PublicArchive : PublicMessage, IArchive {
    public MessageFrameType? FrameType { get; set; }
    [MaxLength(500)]
    public string? Note { get; set; }
    
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

public class PublicArchiveModelCreation : IModelCreationSettings<PublicArchive> {
    public void OnModelCreating(EntityTypeBuilder<PublicArchive> builder, ModelBuilder mb) {
        builder.HasIndex(e => new { e.LandmarkId, e.Created });
    }
}