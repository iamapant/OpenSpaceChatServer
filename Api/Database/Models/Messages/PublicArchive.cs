using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Database.Models;

[Table("PublicArchives")]
public class PublicArchive : PublicMessage {
    [MaxLength(500)]
    public string? Note { get; set; }
    
    public MessageDecoration? Decoration { get; set; }
    
    public ICollection<ArchiveSticker> ArchivedStickers { get; set; } = new List<ArchiveSticker>();
}

public class PublicArchiveModelCreation : IModelCreationSettings<PublicArchive> {
    public void OnModelCreating(EntityTypeBuilder<PublicArchive> builder, ModelBuilder mb) {
        builder.HasIndex(e => new { e.LandmarkId, e.Created });
    }
}