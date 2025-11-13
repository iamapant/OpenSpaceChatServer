using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Api.Database.Models;

[Table("SupportTickets")]
public class SupportTicket {
    [Key]
    public Guid Id { get; set; }
    [ForeignKey(nameof(User))]
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    
    [Required, MaxLength(100)]
    public string Type { get; set; } = null!;       //Add-Remove landmark, report user,  request feature, chat with admin,...
    [Required, MaxLength(250)]
    public string Title { get; set; } = null!;
    [Required, MaxLength(2048)]
    public string Content { get; set; } = null!;
    [MaxLength(500)]
    public string? Tags { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public Position? Position => Latitude != null && Longitude != null ? new ((double)Latitude, (double)Longitude) : null;
    
    public ICollection<SupportTicketData>? Data { get; set; }
    public ICollection<SupportTicketResponse>? Responses { get; set; }
}

public class SupportTicketModelCreation : IModelCreationSettings<SupportTicket> {
    public void OnModelCreating(EntityTypeBuilder<SupportTicket> builder, ModelBuilder mb) {
        builder.Property(e => e.Id).HasValueGenerator<SequentialGuidValueGenerator>().ValueGeneratedOnAdd();
    }
}