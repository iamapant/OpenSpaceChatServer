using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Database.Models;

[Table("OldPasswords")]
public class OldPassword {
    [ForeignKey(nameof(User))]
    public Guid UserId { get; set; }
    [Required, MaxLength(260)]
    public string PasswordHash { get; set; } = null!;
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime ExpiredAt { get; set; }
    
    public User User { get; set; } = null!;
}

public class OldPasswordModelCreation : IModelCreationSettings<OldPassword> {
    public void OnModelCreating(EntityTypeBuilder<OldPassword> builder, ModelBuilder mb) {
        builder.HasKey(e => new {e.UserId, e.ExpiredAt}).HasName("PK_OldPassword");
    }
}