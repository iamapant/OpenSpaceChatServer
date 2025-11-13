// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;
// using System.Drawing;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;
//
// namespace Api.Database.Models;
//
// [Table("UserMessageDecorations")]
// public class UserMessageDecoration {
//     [Key, ForeignKey(nameof(User))]
//     public Guid UserId { get; set; }
//     [ForeignKey(nameof(Frame))]
//     public Guid? FrameId { get; set; }
//     public Frame? Frame { get; set; }
//     
//     [ForeignKey(nameof(FrameOptions))]
//     public Guid? FrameOptionsId { get; set; }
//     public FrameOptions? FrameOptions { get; set; } 
//     
//     [ForeignKey(nameof(NoteFontStyle))]
//     public Guid? NoteFontStyleId { get; set; }
//     public FontStyle? NoteFontStyle { get; set; } 
//     
//     [ForeignKey(nameof(NoteFontFamily))]
//     public Guid? NoteFontFamilyId { get; set; }
//     public FontFamily? NoteFontFamily { get; set; } 
//     public Color? MessageColorPrimary { get; set; }
//     public Color? MessageColorSecondary { get; set; }
//     
//     public User User { get; set; } = null!;
// }
// public class UserMessageDecorationModelCreation : IModelCreationSettings<UserMessageDecoration> {
//     public void OnModelCreating(EntityTypeBuilder<UserMessageDecoration> builder, ModelBuilder mb) {
//         builder.Property(e => e.MessageColorPrimary)
//                .HasConversion(ModelCreationValueConverter.ColorConverter);
//         builder.Property(e => e.MessageColorSecondary)
//                .HasConversion(ModelCreationValueConverter.ColorConverter);
//     }
// }