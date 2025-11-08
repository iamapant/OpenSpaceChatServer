using System.Diagnostics;
using Api.Database;
using Api.Database.Models;
using Api.DTO;
using Microsoft.EntityFrameworkCore;

namespace Api.DAL;

public abstract class MessageRepository<T> : DatabaseRepository<T> where T : class {
    protected DbSet<MessageReaction> _reactions;
    protected DbSet<Message> _messages;

    protected MessageRepository(AppDbContext context) : base(context) {
        _reactions = context.Reactions;
        _messages = context.Messages;
    }

    //Reaction


    //Archive
    public void ArchivePrivateMessage(string id, ArchivePrivateMessageDto dto) { }

    public void UnarchivedPrivateMessage(string id) { }

    public void ArchivePublicMessage(string id, ArchivePublicMessageDto dto) { }
    public void UnarchivePublicMessage(string id) { }

    //Get
    public async Task<ValidationResult<ICollection<PrivateMessage>>> GetMessageByInbox(
        string inboxId) {
        try {
            if (!Guid.TryParse(inboxId, out var id))
                throw new Exception("Cannot parse ID");

            return new(
                await _messages.OfType<PrivateMessage>()
                               .Where(e => e.InboxId == id)
                               .ToListAsync());
        } catch (Exception e) { return new(e); }
    } //Also get private archives. Archives are cast to private message

    public async Task<ValidationResult<ICollection<PublicMessage>>> GetMessageByChannel(string channelId) {
        try {
            if (!Guid.TryParse(channelId, out var id))
                throw new Exception("Cannot parse ID");

            return new(
                await _messages.OfType<PublicMessage>()
                               .Where(e => e.Channels.Any(c => c.Id == id))
                               .ToListAsync());
        } catch (Exception e) { return new(e); }
    } //Also get public archives. Archives are cast to public message

    //Get by location
    public async Task<ICollection<Message>> GetMessagesByLocation(Position position
      , double range) {
        try {
            return await _messages
                         .Where(m => m.Position.DistanceTo(position) <= range)
                         .ToListAsync();
        } catch (Exception e) {
            Debug.WriteLine(e);
            return [];
        }
    }
}