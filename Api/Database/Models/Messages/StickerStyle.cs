using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Api.Database.Models;

[Table("StickerStyles")]
public class StickerStyle {
    [Key]
    public Guid Id { get; set; }
    public double PositionX { get; set; }
    public double PositionY { get; set; }
    public Position Position => new(PositionX, PositionY); 
    public double Width { get; set; }
    public double Height { get; set; }
    public Position Size => new(Width, Height);
    public float Rotation { get; set; }
    
    
    public ICollection<ArchiveSticker> ArchivedStickers { get; set; } = new List<ArchiveSticker>();
    // public ICollection<PublicArchive>? PublicArchives { get; set; }
    // public ICollection<PrivateArchive>? PrivateArchives { get; set; }
}

public class StickerStyleModelCreation : IModelCreationSettings<StickerStyle> {
    public void OnModelCreating(EntityTypeBuilder<StickerStyle> builder, ModelBuilder mb) {
        builder.Property(e => e.Id).HasValueGenerator<SequentialGuidValueGenerator>().ValueGeneratedOnAdd();
    }
}