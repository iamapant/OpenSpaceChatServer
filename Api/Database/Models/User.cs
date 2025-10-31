using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Api.Database.Models;

[Table("Users")]
public class User {
    [Key]
    public Guid Id { get; set; }
    [Required, MaxLength(30)]
    public string Name { get; set; } = null!;
    [Required, MaxLength(260)]
    public string PasswordHash { get; set; } = null!;
    [Required]
    public bool IsActive { get; set; } = true;
    
    [Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime Created { get; set; }
    public DateTime? LastLogin { get; set; }
    
    [MaxLength(128)]
    public string? RefreshToken { get; set; }
    
    public UserTimeout Timeout { get; set; } = null!;
    public UserInfo UserInfo { get; set; } = null!;
    public UserMessageDecoration MessageDecoration { get; set; } = null!;
    [ForeignKey(nameof(Role))]
    public Guid RoleId { get; set; }
    public Role Role { get; set; } = null!;
    
    public ICollection<MessageReaction> Reactions { get; set; } = new List<MessageReaction>();
    
    public ICollection<UserBlacklist> Blacklists { get; set; } = new List<UserBlacklist>();
    public ICollection<UserBlacklist> BlacklistedBys { get; set; } = new List<UserBlacklist>();
    public ICollection<Inbox> Inboxes { get; set; } = new List<Inbox>();
    public ICollection<Channel> Channels { get; set; } = new List<Channel>();
}

public class UserModelCreation : IModelCreationSettings<User> {
    public void OnModelCreating(EntityTypeBuilder<User> builder, ModelBuilder mb) {
        builder.Property(e => e.Id).HasValueGenerator<SequentialGuidValueGenerator>().ValueGeneratedOnAdd();
        builder.HasIndex(e => e.Name).IsUnique();
    }
}