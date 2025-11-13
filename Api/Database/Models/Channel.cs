// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;
// using Microsoft.EntityFrameworkCore.ValueGeneration;
//
// namespace Api.Database.Models;
//
// [Table("Channels")]
// public class Channel {
//     [Key]
//     public Guid Id { get; set; }
//     [Required]
//     public double Latitude { get; set; }
//     [Required]
//     public double Longitude { get; set; }
//     public Position Center => new (Latitude, Longitude);
//     [Required, Range(0.1, 1000)]
//     public double Radius { get; set; }
//
//     public ChannelSetting Setting { get; set; } = null!;
//     
//     public ICollection<PublicMessage> Messages { get; set; }  = new List<PublicMessage>(); 
//     // public ICollection<PublicArchive> Archives { get; set; }  = new List<PublicArchive>(); 
//     public ICollection<UserTimeout> UserTimeouts { get; set; } = new List<UserTimeout>();
// }
//
// public class ChannelModelCreation : IModelCreationSettings<Channel> {
//     public void OnModelCreating(EntityTypeBuilder<Channel> builder, ModelBuilder mb) {
//         builder.Property(e => e.Id).HasValueGenerator<SequentialGuidValueGenerator>().ValueGeneratedOnAdd();
//         builder.HasIndex(e => new { e.Latitude, e.Longitude }).IsUnique(true);
//     }
// }