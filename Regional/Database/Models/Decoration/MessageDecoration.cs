using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Regional.Database.Models;

[Table("MessageDecorations")]
public class MessageDecoration {
    [ForeignKey(nameof(Message)), MaxLength(100)]
    public string MessageId { get; set; } = null!;

    public Message Message { get; set; } = null!;

    //Decoration
    [ForeignKey(nameof(Decoration))]
    public Guid DecorationId { get; set; }
    public Decoration Decoration { get; set; } = null!;
}