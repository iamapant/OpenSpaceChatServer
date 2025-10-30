using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Api.Database.Models;

[Table("Inboxes")]
public class Inbox {
    [Key]
    public Guid Id { get; set; }
    [Required, MaxLength(150)]
    public string Name { get; set; } = null!;
    
    public ICollection<PrivateMessage> Messages { get; set; } = new List<PrivateMessage>();
    public ICollection<User> Users { get; set; } = new List<User>();
}
public class InboxModelCreation : IModelCreationSettings<Inbox> {
    public void OnModelCreating(EntityTypeBuilder<Inbox> builder, ModelBuilder mb) {
        builder.Property(e => e.Id).HasValueGenerator<SequentialGuidValueGenerator>().ValueGeneratedOnAdd();
    }
}