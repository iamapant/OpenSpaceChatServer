using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Api.Database.Models;

[Table("SupportTicketData")]
public class SupportTicketData {
    [Key]
    public Guid Id { get; set; }
    [Required, MaxLength(10)]
    public string Type { get; set; } = null!;
    [Required, MaxLength(2048)]
    public string Content { get; set; } = null!;
    
    [ForeignKey(nameof(SupportTicket))]
    public Guid SupportTicketId { get; set; }
    public SupportTicket SupportTicket { get; set; } = null!;
}

public class SupportTicketDataModelCreation : IModelCreationSettings<SupportTicketData> {
    public void OnModelCreating(EntityTypeBuilder<SupportTicketData> builder, ModelBuilder mb) {
        builder.Property(e => e.Id).HasValueGenerator<SequentialGuidValueGenerator>().ValueGeneratedOnAdd();
    }
}