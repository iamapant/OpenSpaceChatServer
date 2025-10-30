using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Api.Database.Models;

/// <summary>
/// For video, photo, message, inbox, public message (copy the message),... 
/// </summary>
[Table(nameof(ReportData))]
public class ReportData {
    [Key]
    public Guid Id { get; set; }
    [ForeignKey(nameof(SupportTicket))]
    public Guid ReportId { get; set; }
    public SupportTicket SupportTicket { get; set; } = null!;
    
    [Required]
    public string DataType { get; set; } = string.Empty;
    [Required]
    public string Data { get; set; } = string.Empty;
}
public class ReportDataModelCreation : IModelCreationSettings<ReportData> {
    public void OnModelCreating(EntityTypeBuilder<ReportData> builder, ModelBuilder mb) {
        builder.Property(e => e.Id).HasValueGenerator<SequentialGuidValueGenerator>().ValueGeneratedOnAdd();
    }
}