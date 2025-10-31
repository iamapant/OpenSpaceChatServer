using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Database.Models;

public class UserBlacklist {
    [ForeignKey(nameof(User))]
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    [ForeignKey(nameof(Blacklist))]
    public Guid BlacklistId { get; set; }
    public User Blacklist { get; set; } = null!;
    
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime Since { get; set; }
    public bool Temporary { get; set; }
    public DateTime Until { get; set; } = DateTime.MaxValue;
}
public class UserBlacklistModelCreation : IModelCreationSettings<UserBlacklist> {
    public void OnModelCreating(EntityTypeBuilder<UserBlacklist> builder, ModelBuilder mb) {
        builder.HasKey(t => new { t.UserId, t.BlacklistId });
        builder.Property(e => e.Temporary).HasDefaultValue(false);
        builder.HasOne(e => e.User).WithMany(e => e.Blacklists).HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(e => e.Blacklist).WithMany(e => e.BlacklistedBys).HasForeignKey(e => e.BlacklistId).OnDelete(DeleteBehavior.Cascade);
    }
}