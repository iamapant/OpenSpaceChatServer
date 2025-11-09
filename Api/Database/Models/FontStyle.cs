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
    public string? TextDecoration { get; set; }     //Underline, overline, strikethrough
    [MaxLength(10)]
    public string? TextTransform  { get; set; }     //Uppercase, lowercase

    public const string DefaultId = "019a62f8-b759-7fef-b336-101f7a31d111";
    public const int DefaultWeight = 400;
    public const float DefaultSize = 14;
    public const float DefaultLetterSpacing = 0f;
    public const float DefaultLineSpacing = 0f;
    
    
    public ICollection<UserInfo> UserDefaults { get; set; } = new List<UserInfo>();
    // public ICollection<PrivateMessage> PrivateMessages { get; set; } = new List<PrivateMessage>();
    public ICollection<PrivateArchive> PrivateArchives { get; set; } = new List<PrivateArchive>();
    // public ICollection<PublicMessage> PublicMessages { get; set; } = new List<PublicMessage>();
    public ICollection<PublicArchive> PublicArchives { get; set; } = new List<PublicArchive>();
}

public class FontStyleModelCreation : IModelCreationSettings<FontStyle> {
    public void OnModelCreating(EntityTypeBuilder<FontStyle> builder, ModelBuilder mb) {
        builder.Property(e => e.Id).HasValueGenerator<SequentialGuidValueGenerator>().ValueGeneratedOnAdd();
        builder.Property(e => e.Weight).HasDefaultValue(400);
        builder.Property(e => e.SizeInPx).HasDefaultValue(14);
        builder.Property(e => e.LetterSpacing).HasDefaultValue(0);
        builder.Property(e => e.LineSpacing).HasDefaultValue(1.2f);
        builder.HasData(new {
            Id = Guid.Parse(FontStyle.DefaultId)
          , Weight = FontStyle.DefaultWeight
          , SizeInPx = FontStyle.DefaultSize
          , LetterSpacing = FontStyle.DefaultLetterSpacing
          , LineSpacing = FontStyle.DefaultLineSpacing
        });
    }
}