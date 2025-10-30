using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Api.Database.Models;

[Table("MessageStickerStyles")]
public class MessageStickerStyle {
    [Key]
    public Guid Id { get; set; }
    [Required, MaxLength(2048)]
    public string StickerUrl { get; set; } = string.Empty;
    public double PositionX { get; set; }
    public double PositionY { get; set; }
    public Coordinate Position => new(PositionX, PositionY); 
    public double SizeX { get; set; }
    public double SizeY { get; set; }
    public Coordinate Size => new(SizeX, SizeY);
    public float Rotation { get; set; }
    
    public ICollection<PublicArchive>? PublicArchives { get; set; }
    public ICollection<PrivateArchive>? PrivateArchives { get; set; }
}

public class MessageStickerStyleModelCreation : IModelCreationSettings<MessageStickerStyle> {
    public void OnModelCreating(EntityTypeBuilder<MessageStickerStyle> builder, ModelBuilder mb) {
        builder.Property(e => e.Id).HasValueGenerator<SequentialGuidValueGenerator>().ValueGeneratedOnAdd();
    }
}