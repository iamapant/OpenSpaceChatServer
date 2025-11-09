using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Database.Models;

[Table("UserMessageDecorations")]
public class UserMessageDecoration {
    [Key, ForeignKey(nameof(User))]
    public Guid UserId { get; set; }
    [ForeignKey(nameof(Frame))]
    public Guid? FrameId { get; set; }
    public Frame? Frame { get; set; }
    
    [ForeignKey(nameof(FrameOptions))]
    public Guid? FrameOptionsId { get; set; }
    public FrameOptions? FrameOptions { get; set; } 
    
    [ForeignKey(nameof(NoteFontStyle))]
    public Guid? NoteFontStyleId { get; set; }
    public FontStyle? NoteFontStyle { get; set; } 
    
    [ForeignKey(nameof(NoteFontFamily))]
    public Guid? NoteFontFamilyId { get; set; }
    public FontFamily? NoteFontFamily { get; set; } 
    
    public User User { get; set; } = null!;
}