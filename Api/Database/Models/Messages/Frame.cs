using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Api.Database.Models;

[Table("Frames")]
public class Frame {
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;

    public const string Default = "Default";
    public const string DefaultId = "019a36b6-44a9-7484-9d3a-91c305018ac8";
    
    public ICollection<UserInfo> UserDefaults { get; set; } = new List<UserInfo>();
    // public ICollection<PrivateMessage> PrivateMessages { get; set; } = new List<PrivateMessage>();
    public ICollection<PrivateArchive> PrivateArchives { get; set; } = new List<PrivateArchive>();
    // public ICollection<PublicMessage> PublicMessages { get; set; } = new List<PublicMessage>();
    public ICollection<PublicArchive> PublicArchives { get; set; } = new List<PublicArchive>();
}

public class FrameModelCreation : IModelCreationSettings<Frame> {
    public void OnModelCreating(EntityTypeBuilder<Frame> builder, ModelBuilder mb) {
        builder.Property(e => e.Id).HasValueGenerator<SequentialGuidValueGenerator>().ValueGeneratedOnAdd();
        builder.HasData(new Frame { Id = Guid.Parse(Frame.DefaultId), Name = Frame.Default });
        
    }
}