using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Database.Models;

[Table(nameof(CuratorSettings))]
public class CuratorSettings {
    [Key]
    public int Id { get; set; } = 1;
    public float DefaultMessageDurationInHour { get; set; }
    public int DefaultMessageHighlightThreshold { get; set; }
    public int DefaultMessageArchiveThreshold { get; set; }
    public double DefaultChannelRadiusInKm { get; set; }
    public float LandmarkTaggableRangeInKm { get; set; }
    public float UserChatRangeInKm { get; set; }
    public float PrivateMessagePublishDeadlineInHour { get; set; }
    public float PublicMessageFrequencyPerInterval { get; set; }
    public int PublicMessageFrequencyIntervalInSecond { get; set; }
    public float DefaultTimeoutPeriodInMinute { get; set; }
}

public class CuratorSettingsCreationModel : IModelCreationSettings<CuratorSettings> {
    public void OnModelCreating(EntityTypeBuilder<CuratorSettings> builder, ModelBuilder mb) {

        builder.HasData(new CuratorSettings{
            Id = 1,
            DefaultMessageDurationInHour = 2,
            DefaultMessageHighlightThreshold = 5,
            DefaultMessageArchiveThreshold = 20,
            DefaultChannelRadiusInKm = 1,                   //1km
            LandmarkTaggableRangeInKm = 0.1f,               //100m
            UserChatRangeInKm = 0.3f,                       //300m
            PrivateMessagePublishDeadlineInHour = 0.25f,    //15min
            PublicMessageFrequencyPerInterval = 5,
            PublicMessageFrequencyIntervalInSecond = 5,
            DefaultTimeoutPeriodInMinute = 20,
        });
    }
}