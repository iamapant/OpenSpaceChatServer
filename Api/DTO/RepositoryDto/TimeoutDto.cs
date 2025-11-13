using System.ComponentModel.DataAnnotations;
using Api.Database.Models;

namespace Api.DTO;

public class TimeoutDto : IAddDto<UserTimeout>, IUpdateDto<UserTimeout> {
    [Required]
    public string UserId { get; set; }
    [Required]
    public string ChannelId { get; set; }
    [Required, Range(0.1f, float.MaxValue)]
    public float TimeoutPeriodInHour { get; set; }
    
    public UserTimeout? Map() {
        try {
            if (!Guid.TryParse(UserId, out var userId)
                || Guid.TryParse(ChannelId, out var channelId)) return null;
            return new UserTimeout {
                UserId = userId
              // , ChannelId = channelId
              , TimeoutEnd = DateTime.UtcNow.AddHours(TimeoutPeriodInHour)
            };
        }catch { return null; }
    }

    public void Map(UserTimeout entity) {
        // if (Guid.TryParse(ChannelId, out var channelId)) entity.ChannelId = channelId;
        entity.TimeoutEnd = DateTime.UtcNow.AddHours(TimeoutPeriodInHour);
    }
}