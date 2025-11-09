using System.ComponentModel.DataAnnotations;
using Api.Database.Models;

namespace Api.DTO;

public class MessageReactionDto : IAddDto<Reaction> {
    [Required]
    public string UserId { get; set; } = null!;
    [Required]
    public string MessageId { get; set; } = null!;
    [Required]
    public string Reaction { get; set; } = null!;
    public Reaction? Map() {
        if (!Guid.TryParse(UserId, out var userId))
            return null;
        return new Reaction {
            UserId = userId, MessageId = MessageId, ReactionType = Reaction
        };
    }
}

public class RemoveMessageReactionDto {
    [Required]
    public string UserId { get; set; } = null!;
    [Required]
    public string MessageId { get; set; } = null!;
}