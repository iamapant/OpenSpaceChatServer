using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Regional.DTO;

namespace Regional.Database.Models.Timeout;

public class TimeoutVote {
    [ForeignKey(nameof(User))]
    public Guid UserId { get; set; }
    [ForeignKey(nameof(TimeoutUser))]
    public Guid TimeoutUserId { get; set; }
    [Required]
    public VoteOptions Vote { get; set; }
    
    public User User { get; set; } = null!;
    public User TimeoutUser { get; set; } = null!;
}

public class TimeoutVoteModelCreation : IModelCreationSettings<TimeoutVote> {
    public void OnModelCreating(EntityTypeBuilder<TimeoutVote> builder, ModelBuilder mb) {
        builder.HasKey(e => new { e.UserId, e.TimeoutUserId });
    }
}