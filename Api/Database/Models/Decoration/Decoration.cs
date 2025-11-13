using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Api.Database.Models;

[Table("Decorations")]
public class Decoration {
    [Key]
    public Guid Id { get; set; }
    
    [ForeignKey(nameof(FontFamily))]
    public Guid FontFamilyId { get; set; }
    [ForeignKey(nameof(FontStyle))]
    public Guid FontStyleId { get; set; }
    [ForeignKey(nameof(Frame))]
    public Guid FrameId { get; set; }
    [ForeignKey(nameof(FrameOptions))]
    public Guid FrameOptionsId { get; set; }
    
    public FontFamily FontFamily { get; set; } = null!;
    public FontStyle FontStyle { get; set; } = null!;
    public Frame Frame { get; set; } = null!;
    public FrameOptions FrameOptions { get; set; } = null!;
    
    public ICollection<MessageDecoration> Messages { get; set; } = new List<MessageDecoration>();
    public ICollection<UserDecoration> Users { get; set; } = new List<UserDecoration>();
}

public class DecorationModelCreation : IModelCreationSettings<Decoration> {
    public void OnModelCreating(EntityTypeBuilder<Decoration> builder, ModelBuilder mb) {
        builder.Property(e => e.Id).HasValueGenerator<GuidValueGenerator>();
    }
}