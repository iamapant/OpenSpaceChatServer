using System.Diagnostics;
using Api.Database;
using Api.Database.Models;
using Api.DTO;
using Microsoft.EntityFrameworkCore;

namespace Api.DAL;

public class StickerRepository : DatabaseRepository<MessageStickerStyle> {
    private readonly DbSet<MessageStickerUrl> _urls;

    public StickerRepository(AppDbContext context) : base(context) {
        _urls = context.Set<MessageStickerUrl>();
    }

    [Obsolete("This dto isn't supported for adding reactions.")]
    public override Task<ValidationResult<MessageStickerStyle>> Add(IAddDto<MessageStickerStyle> dto) =>
        throw new NotImplementedException(dto.GetType().Name);

    public async Task<ValidationResult<MessageStickerStyle>> Add(StickerDto dto) {
        try {
            //Message
            var message = await _context.Set<Message>().FindAsync(dto.MessageId);
            if (message == null) throw new Exception("Message not found.");
            
            //Url
            if (!IsStickerUrl(dto.StickerUrl)) throw new Exception("Sticker url is not valid");
            MessageStickerUrl? url = await _urls.FirstOrDefaultAsync(o => o.StickerUrl == dto.StickerUrl);
            if (url == null) throw new Exception("Url not found.");
            
            //Style
            MessageStickerStyle? style = await _entity.FirstOrDefaultAsync(e => dto.Position == e.Position && Math.Abs(dto.RotationDeg - e.Rotation) < 0.000000001f && dto.Size == e.Size);
            if (style == null) {
                style = new MessageStickerStyle() {
                    PositionX = dto.Position.Longitude
                  , PositionY = dto.Position.Latitude
                  , Height = dto.Size.Latitude
                  , Width = dto.Size.Longitude
                  , Rotation = dto.RotationDeg
                };
                
                await _entity.AddAsync(style);
                await _context.SaveChangesAsync();
            }

            //Add relation and return
            switch (message) {
                case PrivateArchive pri:
                    url.PrivateArchives?.Add(pri);
                    style.PrivateArchives?.Add(pri);
                    break;
                case PublicArchive pup:
                    url.PublicArchives?.Add(pup);
                    style.PublicArchives?.Add(pup);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(message.GetType().Name);
            }
            _context.Set<MessageStickerUrl>().Update(url);
            _entity.Update(style);
            await _context.SaveChangesAsync();
            
            return new (style);
        } catch (Exception ex) { return new (ex); }
    }

    private bool IsStickerUrl(string dtoStickerUrl) {
        //TODO: discrimination logic for sticker url
        return true;
    }

    public async Task RemoveUnused(ILogger log) {
        try {
            var urls = _urls.Where(e => e.PrivateArchives!.Count == 0 && e.PublicArchives!.Count == 0);
            var style = _entity.Where(e => e.PrivateArchives!.Count == 0 && e.PublicArchives!.Count == 0);

            _urls.RemoveRange(urls);
            _entity.RemoveRange(style);
            var affected = await _context.SaveChangesAsync();
            log.LogInformation($"Removed {affected} unused sticker styles.");
        } catch (Exception ex) {
            log.LogError(ex, "Could not remove unused sticker styles.");
        }
    }
}
