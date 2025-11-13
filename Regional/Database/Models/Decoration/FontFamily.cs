using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Regional.Database.Models;

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