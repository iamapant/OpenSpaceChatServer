using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Api.Database.Models;

[Table("MessageFrameOptions")]
public class MessageFrameOptions {
    [Key]
    public Guid Id { get; set; }
    public Color ColorPrimary { get; set; }
    public Color ColorSecondary { get; set; }
    //TODO: Options...


    public ICollection<PublicArchive>? PublicArchives { get; set; }
    public ICollection<PrivateArchive>? PrivateArchives { get; set; }
}
public class MessageFrameOptionsModelCreation : IModelCreationSettings<MessageFrameOptions> {
    public void OnModelCreating(EntityTypeBuilder<MessageFrameOptions> builder, ModelBuilder mb) {
        builder.Property(e => e.Id).HasValueGenerator<SequentialGuidValueGenerator>().ValueGeneratedOnAdd();
        builder.Property(e => e.ColorPrimary).HasConversion(ModelCreationValueConverter.ColorConverter);
        builder.Property(e => e.ColorSecondary).HasConversion(ModelCreationValueConverter.ColorConverter);
    }
}