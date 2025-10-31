using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Database.Models;

[Table("ChannelSettings")]
public class ChannelSetting {
    [Key, ForeignKey(nameof(Channel))]
    public Guid Id { get; set; }
    /// <summary>
    /// Minimum timespan the message is stored
    /// </summary>
    public TimeSpan MessageDuration { get; set; }
    
    /// <summary>
    /// How many reactions for this message to be highlighted
    /// </summary>
    public int? MessageHighlightThreshold { get; set; }
    /// <summary>
    /// How many reactions for this message to be archived
    /// </summary>
    public int? MessageArchiveThreshold { get; set; } 

    public Channel Channel { get; set; } = null!;
}

public class ChannelSettingModelCreation : IModelCreationSettings<ChannelSetting> {
    public void OnModelCreating(EntityTypeBuilder<ChannelSetting> builder
        , ModelBuilder mb) {
        builder.Property(e => e.MessageDuration)
            .HasConversion(ModelCreationValueConverter.TimeSpanConverter);
    }
}