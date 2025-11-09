using Api.DAL;
using Api.Database;
using Api.Database.Models;
using Api.DTO;
using Microsoft.EntityFrameworkCore;

namespace Api.Services;

public class MessageService {
    private readonly PrivateMessageRepository _privateMessage;
    private readonly PublicMessageRepository _publicMessage;
    private readonly PrivateArchiveRepository _privateArchive;
    private readonly PublicArchiveRepository _publicArchive;
    private readonly FrameRepository _frame;
    private readonly FrameOptionsRepository _frameOptions;
    private readonly UserRepository _user;
    private readonly AppDbContext _context;
    private readonly GlobalSettings _settings;
    private readonly StickerUrlRepository _stickerUrl;
    private readonly StickerStyleRepository _stickerStyle;
    public MessageService(PrivateMessageRepository privateMessage, PublicMessageRepository publicMessage, PrivateArchiveRepository privateArchive, PublicArchiveRepository publicArchive, AppDbContext context, FrameRepository frame, FrameOptionsRepository frameOptions, UserRepository user, GlobalSettings settings, StickerUrlRepository stickerUrl, StickerStyleRepository stickerStyle) {
        _privateMessage = privateMessage;
        _publicMessage = publicMessage;
        _privateArchive = privateArchive;
        _publicArchive = publicArchive;
        _context = context;
        _frame = frame;
        _frameOptions = frameOptions;
        _user = user;
        _settings = settings;
        _stickerUrl = stickerUrl;
        _stickerStyle = stickerStyle;
    }

    public async Task<ValidationResult<PrivateArchive>> Archive(ArchivePrivateMessageDto dto) {
        try {
            var message = await _privateMessage.FindById(dto.Id) ?? throw new Exception("Message not found.");
            await _privateMessage.Load(message, e => e.Reactions);
            var user = await _user.Find(message.UserId);
            if (user == null) throw new Exception("User not found.");
            await _user.Load(user, u => u.MessageDecoration);
            var decoration = GetUserDecoration(user.MessageDecoration);
            
            //Create new object archive with data from dto and old message
            var archive = dto.Map();
            if (archive == null) throw new Exception("Cannot map dto to new archive.");
            //Transfer data from message to archive
            await HandleFrame(decoration, dto);
            await HandleFont(decoration, dto);
            //Handle unmapped properties from the dto
            await HandleStickers(decoration, dto);
            //Detach message
            _context.Entry(message).State = EntityState.Detached;
            
            
            archive.FrameId = decoration.FrameId;
            archive.FrameOptionsId = decoration.FrameOptionsId;
            archive.NoteFontFamilyId = decoration.FontFamilyId;
            archive.NoteFontStyleId = decoration.FontStyleId;
            
            
            //ADD new archived message
            _context.Set<PrivateArchive>().Add(archive);
            await _context.SaveChangesAsync();
            return new(archive);
        } catch (Exception e) { return new(e); }
    }

    private async Task HandleFont(MessageDecorationDto decoration, ArchivePrivateMessageDto dto) {
        throw new NotImplementedException();
    }

    private async Task HandleFrame(MessageDecorationDto decoration, ArchivePrivateMessageDto dto) {
        throw new NotImplementedException();
    }

    private async Task HandleStickers(MessageDecorationDto decoration, ArchivePrivateMessageDto dto) {
        if (dto.Stickers == null) return;
        List<(Guid Url, Guid Style)> stickers = new List<(Guid Url, Guid Style)>(); 
        foreach (var sticker in dto.Stickers) {
            var style = await _stickerStyle.GetOrSetStyle(sticker.Position
              , sticker.Size
              , sticker.RotationDeg);
            var url = await _stickerUrl.GetOrSetUrl(sticker.StickerUrl);
            stickers.Add((url.Id, style.Id));
        }
        
        decoration.Stickers.AddRange(stickers);
    }

    private MessageDecorationDto GetUserDecoration(UserMessageDecoration user) {
        return new MessageDecorationDto {
            FontFamilyId = user.NoteFontFamilyId ?? _settings.Decoration.FontFamilyId
          , FontStyleId = user.NoteFontStyleId ?? _settings.Decoration.FontStyleId
          , FrameId = user.FrameId ?? _settings.Decoration.FrameId
          , FrameOptionsId = user.FrameOptionsId ?? _settings.Decoration.FrameOptionsId
        };
    }
    

    public async Task<ValidationResult<PublicArchive>> Archive(ArchivePublicMessageDto dto) {
        try {
            throw new NotImplementedException();
        } catch (Exception e) { return new(e); }
    }
}