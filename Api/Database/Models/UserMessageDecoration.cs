using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Database.Models;

[Table("UserMessageDecorations")]
public class UserMessageDecoration {
    [Key, ForeignKey(nameof(User))]
    public Guid UserId { get; set; }
    [ForeignKey(nameof(Frame))]
    public Guid? FrameId { get; set; }
    public MessageFrame? Frame { get; set; }
    
    [ForeignKey(nameof(FrameOptions))]
    public Guid? FrameOptionsId { get; set; }
    public MessageFrameOptions? FrameOptions { get; set; } = null!;
    
    [ForeignKey(nameof(NoteFontStyle))]
    public Guid? NoteFontStyleId { get; set; }
    public FontStyle? NoteFontStyle { get; set; } = null!;
    
    [ForeignKey(nameof(NoteFontFamily))]
    public Guid? NoteFontFamilyId { get; set; }
    public FontFamily? NoteFontFamily { get; set; } = null!;
    
    public User User { get; set; } = null!;
}