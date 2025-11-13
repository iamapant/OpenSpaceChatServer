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

    public const string DefaultId = "019a62f7-4772-7b75-bf90-a279409799de";
    public const string DefaultFamily = "Arial";
    
    public ICollection<MessageDecoration> Messages { get; set; } = new List<MessageDecoration>();
    public ICollection<UserDecoration> Users { get; set; } = new List<UserDecoration>();
}

public class FontFamilyModelCreation : IModelCreationSettings<FontFamily> {
    public void OnModelCreating(EntityTypeBuilder<FontFamily> builder, ModelBuilder mb) {
        builder.Property(e => e.Id).HasValueGenerator<SequentialGuidValueGenerator>().ValueGeneratedOnAdd();
        builder.HasData(new  FontFamily { Family = FontFamily.DefaultFamily, Id = Guid.Parse(FontFamily.DefaultId) });
    }
}