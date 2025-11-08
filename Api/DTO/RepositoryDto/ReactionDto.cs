using System.ComponentModel.DataAnnotations;
using Api.Database.Models;

namespace Api.DTO;

public class MessageReactionDto : IAddDto<MessageReaction> {
    [Required]
    public string UserId { get; set; } = null!;
    [Required]
    public string MessageId { get; set; } = null!;
    [Required]
    public string Reaction { get; set; } = null!;
    public MessageReaction? Map() {
        if (!Guid.TryParse(UserId, out var userId))
            return null;
        return new MessageReaction {
            UserId = userId, MessageId = MessageId, Reaction = Reaction
        };
    }
}

public class RemoveMessageReactionDto {
    [Required]
    public string UserId { get; set; } = null!;
    [Required]
    public string MessageId { get; set; } = null!;
}