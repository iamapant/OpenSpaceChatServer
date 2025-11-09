using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Api.Database.Models;

/// <summary>
/// Frame options only serves to modify the chosen frame. To change the selected frame, use Message Frame 
/// </summary>
[Table("FrameOptions")]
public class FrameOptions {
    [Key]
    public Guid Id { get; set; }
    public Color ColorPrimary { get; set; }
    public Color ColorSecondary { get; set; }
    //TODO: Options...

    public const string DefaultId = "019a62f1-51a2-71c7-94ce-78748709c6f4";
    public static Color DefaultColorPrimary = Color.White;
    public static Color DefaultColorSecondary = Color.DodgerBlue;
    public ICollection<UserInfo> UserDefaults { get; set; } = new List<UserInfo>();
    public ICollection<PrivateArchive> PrivateArchives { get; set; } = new List<PrivateArchive>();
    public ICollection<PublicArchive> PublicArchives { get; set; } = new List<PublicArchive>();
}
public class FrameOptionsModelCreation : IModelCreationSettings<FrameOptions> {
    public void OnModelCreating(EntityTypeBuilder<FrameOptions> builder, ModelBuilder mb) {
        builder.Property(e => e.Id).HasValueGenerator<SequentialGuidValueGenerator>().ValueGeneratedOnAdd();
        builder.Property(e => e.ColorPrimary).HasConversion(ModelCreationValueConverter.ColorConverter);
        builder.Property(e => e.ColorSecondary).HasConversion(ModelCreationValueConverter.ColorConverter);
        builder.HasData(new {
            Id = Guid.Parse(FrameOptions.DefaultId)
          , ColorPrimary = FrameOptions.DefaultColorPrimary
          , ColorSecondary = FrameOptions.DefaultColorSecondary
        });
    }
}