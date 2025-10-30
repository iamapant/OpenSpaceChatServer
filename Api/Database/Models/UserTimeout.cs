using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Database.Models;

[Table("UserTimeouts")]
public class UserTimeout {
    public Guid UserId { get; set; }
    public Guid ChannelId { get; set; }
    
    public DateTime TimeoutEnd { get; set; }
    
    public User User { get; set; } = null!;
    public Channel Channel { get; set; } = null!;
}

public class UserTimeoutModelCreation : IModelCreationSettings<UserTimeout> {
    public void OnModelCreating(EntityTypeBuilder<UserTimeout> builder, ModelBuilder mb) {
        builder.HasKey(e => new { e.UserId, e.ChannelId });
    }
}