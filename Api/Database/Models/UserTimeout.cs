using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Database.Models;

[Table("UserTimeouts")]
public class UserTimeout {
    [Key, ForeignKey(nameof(User))]
    public Guid UserId { get; set; }
    // [ForeignKey(nameof(Channel))]
    // public Guid ChannelId { get; set; }
    
    public DateTime TimeoutEnd { get; set; }
    
    public User User { get; set; } = null!;
    // public Channel Channel { get; set; } = null!;
}

public class UserTimeoutModelCreation : IModelCreationSettings<UserTimeout> {
    public void OnModelCreating(EntityTypeBuilder<UserTimeout> builder, ModelBuilder mb) {
    }
}