using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Regional.Database.Models;

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
    
    public ICollection<MessageDecoration> Messages { get; set; } = new List<MessageDecoration>();
    public ICollection<UserDecoration> Users { get; set; } = new List<UserDecoration>();
}