using System.ComponentModel.DataAnnotations;
using Api;
using Regional.Database.Models;

namespace Regional.DTO;

public class NewMessageDto : IAddDto<Message> {
    [Required]
    public string UserId { get; set; } = null!;
    
    [Required, MaxLength(20)]
    public string ContentType { get; set; } = null!;
    [Required]
    public string Content { get; set; } = null!;
    public string? InboxId { get; set; }
    public Position? Position { get; set; }
    public string? LandmarkId { get; set; }
    
    public Message? Map() {
        Guid landmarkId = Guid.Empty;
        Guid inboxId = Guid.Empty;
        if (!Guid.TryParse(UserId, out var userId)) return null;
        if (Guid.TryParse(LandmarkId, out var lid))  landmarkId = lid;
        if (Guid.TryParse(InboxId, out var iId)) {
            if (InboxId != null) return null;
            inboxId = iId;
        }
        
        return new Message {
            Id = InboxId == null ? Message.GetIdPublic(UserId, Position.GetValueOrDefault()) : Message.GetIdPrivate(UserId, InboxId)
          , UserId = userId
          , InboxId = InboxId == null ? inboxId : null
          , LandmarkId = landmarkId == Guid.Empty ? null : landmarkId
          , ContentType = ContentType
          , Content = Content
          , Latitude = Position.GetValueOrDefault().Latitude
          , Longitude = Position.GetValueOrDefault().Longitude
          , Created = DateTime.UtcNow
        };
    }
}