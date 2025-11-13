using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace Regional.Database.Models;

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
    
    public ICollection<MessageDecoration> Messages { get; set; } = new List<MessageDecoration>();
    public ICollection<UserDecoration> Users { get; set; } = new List<UserDecoration>();
}