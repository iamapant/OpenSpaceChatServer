using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Regional.Database.Models;

[Table("Frames")]
public class Frame {
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Url { get; set; } = string.Empty;

    public const string Default = "Default";
    public const string DefaultId = "019a36b6-44a9-7484-9d3a-91c305018ac8";
    public const string DefaultUrl = ""; //TODO: Default frame url
    
    public ICollection<MessageDecoration> Messages { get; set; } = new List<MessageDecoration>();
    public ICollection<UserDecoration> Users { get; set; } = new List<UserDecoration>();
}
