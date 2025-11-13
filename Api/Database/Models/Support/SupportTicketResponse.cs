using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Api.Database.Models;

[Table("SupportTicketResponses")]
public class SupportTicketResponse {
    [Key]
    public Guid Id { get; set; }
    [ForeignKey(nameof(SupportTicket))]
    public Guid SupportTicketId { get; set; }
    [ForeignKey(nameof(Curator))]
    public Guid CuratorId { get; set; }
    [Required]
    public string Status { get; set; } = null!;
    [Required]
    public string Response { get; set; } = null!;
    
    public SupportTicket SupportTicket { get; set; } = null!;
    public User Curator { get; set; } = null!;
}

public class SupportTicketResponseModelCreation : IModelCreationSettings<SupportTicketResponse> {
    public void OnModelCreating(EntityTypeBuilder<SupportTicketResponse> builder, ModelBuilder mb) {
        builder.Property(e => e.Id).HasValueGenerator<GuidValueGenerator>();
    }
}