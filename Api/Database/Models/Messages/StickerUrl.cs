using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Api.Database.Models;

[Table("StickerUrls")]
public class StickerUrl {
    [Key]
    public Guid Id { get; set; }
    [Required, MaxLength(2048)]
    public string Url { get; set; } = string.Empty;
    
    public ICollection<ArchiveSticker> ArchivedStickers { get; set; } = new List<ArchiveSticker>();
    // public ICollection<PublicArchive>? PublicArchives { get; set; }
    // public ICollection<PrivateArchive>? PrivateArchives { get; set; }
}
public class StickerUrlModelCreation : IModelCreationSettings<StickerUrl> {
    public void OnModelCreating(EntityTypeBuilder<StickerUrl> builder, ModelBuilder mb) {
        builder.Property(e => e.Id).HasValueGenerator<SequentialGuidValueGenerator>().ValueGeneratedOnAdd();
        builder.HasIndex(e => e.Url).IsUnique();
    }
}