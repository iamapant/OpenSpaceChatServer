using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Database.Models;

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

public class UserDecorationModelCreation : IModelCreationSettings<UserDecoration> {
    public void OnModelCreating(EntityTypeBuilder<UserDecoration> builder, ModelBuilder mb) {
        builder.HasKey(e => new  { e.UserId, e.DecorationId });
    }
}