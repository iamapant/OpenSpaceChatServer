// using System.ComponentModel.DataAnnotations;
// using Api.Database.Models;
//
// namespace Api.DTO;
//
// public class ChannelDto {
//     
// }
//
// public class ChannelSettingsDto : IUpdateDto<ChannelSetting> {
//     [Required]
//     public string Id { get; set; } = null;
//     public float? MessageDurationInHour { get; set; }
//     public int? MessageHighlightThreshold { get; set; }
//     public int? MessageArchiveThreshold { get; set; } 
//
//     public void Map(ChannelSetting entity) {
//         if (MessageDurationInHour.HasValue)entity.MessageDuration = TimeSpan.FromHours(MessageDurationInHour.Value);
//         if (MessageHighlightThreshold.HasValue)entity.MessageHighlightThreshold = MessageHighlightThreshold.Value;
//         if (MessageArchiveThreshold.HasValue)entity.MessageArchiveThreshold = MessageArchiveThreshold.Value;
//     }
// }