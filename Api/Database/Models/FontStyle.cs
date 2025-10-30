using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Api.Database.Models;

[Table("FontStyles")]
public class FontStyle {
    [Key]
    public Guid Id { get; set; }
    public int Weight { get; set; }
    [MaxLength(15)]
    public string? Style { get; set; }      //Italic, oblique
    public float SizeInPx { get; set; }
    public float LetterSpacing { get; set; }
    public float LineSpacing { get; set; }
    [MaxLength(50)]
    public string? TextDecoration { get; set; }
    [MaxLength(10)]
    public string? TextTransform  { get; set; }     //Uppercase, lowercase
}

public class FontStyleModelCreation : IModelCreationSettings<FontStyle> {
    public void OnModelCreating(EntityTypeBuilder<FontStyle> builder, ModelBuilder mb) {
        builder.Property(e => e.Id).HasValueGenerator<SequentialGuidValueGenerator>().ValueGeneratedOnAdd();
        builder.Property(e => e.Weight).HasDefaultValue(400);
        builder.Property(e => e.SizeInPx).HasDefaultValue(14);
        builder.Property(e => e.LetterSpacing).HasDefaultValue(0);
        builder.Property(e => e.LineSpacing).HasDefaultValue(1.2f);
    }
}