using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Database.Models;


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

public class MessageDecorationModelCreation : IModelCreationSettings<MessageDecoration> {
    public void OnModelCreating(EntityTypeBuilder<MessageDecoration> builder, ModelBuilder mb) {
        builder.HasKey(e => new  { e.MessageId, e.DecorationId });
    }
}