using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Api.Database.Models;

[Table("Landmarks")]
public class Landmark {
    [Key]
    public Guid Id { get; set; }

    [Required, MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    [Required, MaxLength(2048)]
    public string IconUrl { get; set; } = string.Empty;
    [MaxLength(300)]
    public string? Description { get; set; }
    [MaxLength(2048)]
    public string? PhotoUrl { get; set; }
    [MaxLength(2048)]
    public string? InfoUrl { get; set; }
    [Required]
    public double Latitude { get; set; }
    [Required]
    public double Longitude { get; set; }
    public Position Position => new (Latitude, Longitude);
    public ICollection<Message> Messages { get; set; } = new List<Message>();
}
public class LandmarkModelCreation : IModelCreationSettings<Landmark> {
    public void OnModelCreating(EntityTypeBuilder<Landmark> builder, ModelBuilder mb) {
        builder.Property(e => e.Id).HasValueGenerator<SequentialGuidValueGenerator>().ValueGeneratedOnAdd();
    }
}