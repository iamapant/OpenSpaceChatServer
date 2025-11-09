using Api.Database;
using Api.Database.Models;
using Api.DTO;
using Microsoft.EntityFrameworkCore;

namespace Api.DAL;

public class MessageReactionRepository : DatabaseRepository<Reaction> {
    public MessageReactionRepository(AppDbContext context) : base(context) { }

    public async Task<ValidationResult> React(MessageReactionDto dto) {
        try {
            var reaction = dto.Map();
            if (reaction == null)
                throw new NullReferenceException("Failed to map reaction from dto.");

            var user = await _context.Set<User>().FindAsync(reaction.UserId);
            if (user == null) throw new NullReferenceException("Cannot find user.");
            var message = await _context.Set<Message>().FindAsync(reaction.MessageId);
            if (message == null) throw new NullReferenceException("Cannot find message.");
            if (await _entity.AnyAsync(e => e.MessageId == message.Id
                 && e.UserId == user.Id)) {
                var oldReaction = await _entity.FirstOrDefaultAsync(e =>
                    e.MessageId == message.Id && e.UserId == user.Id);
                if (oldReaction == null)
                    throw new Exception("Failed to react message from dto.");
                oldReaction.ReactionType = reaction.ReactionType;
                oldReaction.Created = DateTime.UtcNow;

                await Save(oldReaction);
            }
            else { await Add(reaction); }

            return new();
        } catch (Exception e) { return new(e); }
    }

    public async Task<ValidationResult> RemoveReaction(RemoveMessageReactionDto dto) {
        try {
            if (!Guid.TryParse(dto.UserId, out var userId)
             || Guid.TryParse(dto.MessageId, out var messageId))
                throw new Exception("Cannot parse id.");
            var reaction = await Find(userId, messageId);
            if (reaction != null) { (await Remove(reaction)).ThrowIfInvalid(); }

            return new();
        } catch (Exception e) { return new(e); }
    }
}