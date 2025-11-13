using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Api;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Regional.Database.Models.Timeout;

namespace Regional.Database.Models;

[Table("ActiveUsers")]
public class User {
    [Key]
    public Guid Id { get; set; }
    [ForeignKey(nameof(Role))]
    public Guid RoleId { get; set; }
    public DateTime LastActive { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public Position Position => new Position(Latitude, Longitude);
    public Role Role { get; set; } = null!;
    public TimeoutUser IsTimeout { get; set; } = null!;
    public UserDecoration Decoration { get; set; } = null!;
    public ICollection<Inbox> Inboxes { get; set; } = new List<Inbox>();
    public ICollection<Message> Messages { get; set; } = new List<Message>();
    public ICollection<TimeoutVote> VotedTimeouts { get; set; } = new List<TimeoutVote>();
    public ICollection<TimeoutVote> TimeoutVotes { get; set; } = new List<TimeoutVote>();
}
public class UserModelCreation : IModelCreationSettings<User> {
    public void OnModelCreating(EntityTypeBuilder<User> builder, ModelBuilder mb) {
        builder.HasMany(e => e.VotedTimeouts).WithOne(e => e.User);
        builder.HasMany(e => e.TimeoutVotes).WithOne(e => e.TimeoutUser);
    }
}

