using System.ComponentModel.DataAnnotations.Schema;

namespace Regional.Database.Models;

[Table("UserDecorations")]
public class UserDecoration {
    [ForeignKey(nameof(User))]
    public Guid UserId { get; set; } 

    public User User { get; set; } = null!;
    
    //Decoration
    [ForeignKey(nameof(Decoration))]
    public Guid DecorationId { get; set; }
    public Decoration Decoration { get; set; } = null!;
}