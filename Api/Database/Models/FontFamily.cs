using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Api.Database.Models;

[Table("FontFamilies")]
public class FontFamily {
    [Key]
    public Guid Id { get; set; }

    [Required, MaxLength(300)]
    public string Family { get; set; } = string.Empty;
}

public class FontFamilyModelCreation : IModelCreationSettings<FontFamily> {
    public void OnModelCreating(EntityTypeBuilder<FontFamily> builder, ModelBuilder mb) {
        builder.Property(e => e.Id).HasValueGenerator<SequentialGuidValueGenerator>().ValueGeneratedOnAdd();
    }
}