using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Api.Database.Models;

[Table("MessageFrames")]
public class MessageFrame {
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;

    public const string Default = "Default";
    
    public ICollection<UserInfo> UserDefaults { get; set; } = new List<UserInfo>();
    // public ICollection<PrivateMessage> PrivateMessages { get; set; } = new List<PrivateMessage>();
    public ICollection<PrivateArchive> PrivateArchives { get; set; } = new List<PrivateArchive>();
    // public ICollection<PublicMessage> PublicMessages { get; set; } = new List<PublicMessage>();
    public ICollection<PublicArchive> PublicArchives { get; set; } = new List<PublicArchive>();
}

public class MessageFrameModelCreation : IModelCreationSettings<MessageFrame> {
    public void OnModelCreating(EntityTypeBuilder<MessageFrame> builder, ModelBuilder mb) {
        builder.Property(e => e.Id).HasValueGenerator<SequentialGuidValueGenerator>().ValueGeneratedOnAdd();
        builder.HasData(new MessageFrame { Id = Guid.Parse("019a36b6-44a9-7484-9d3a-91c305018ac8"), Name = MessageFrame.Default });
    }
}