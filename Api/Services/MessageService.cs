// using Api.DAL;
// using Api.Database;
// using Api.Database.Models;
// using Api.DTO;
// using Api.Providers.Notification;
// using Microsoft.EntityFrameworkCore;
//
// namespace Api.Services;
//
// public class MessageService {
//     private readonly PrivateMessageRepository _privateMessage;
//     private readonly PublicMessageRepository _publicMessage;
//     private readonly PrivateArchiveRepository _privateArchive;
//     private readonly PublicArchiveRepository _publicArchive;
//     private readonly FrameRepository _frame;
//     private readonly FrameOptionsRepository _frameOptions;
//     private readonly UserRepository _user;
//     private readonly AppDbContext _context;
//     private readonly GlobalSettings _settings;
//     private readonly StickerUrlRepository _stickerUrl;
//     private readonly StickerStyleRepository _stickerStyle;
//     private readonly FontFamilyRepository _fontFamily;
//     private readonly FontStyleRepository _fontStyle;
//     // private readonly ChannelRepository _channel;
//     private readonly IPushNotificationProvider _notification;
//
//     public MessageService(PrivateMessageRepository privateMessage
//       , PublicMessageRepository publicMessage
//       , PrivateArchiveRepository privateArchive
//       , PublicArchiveRepository publicArchive
//       , AppDbContext context
//       , FrameRepository frame
//       , FrameOptionsRepository frameOptions
//       , UserRepository user
//       , GlobalSettings settings
//       , StickerUrlRepository stickerUrl
//       , StickerStyleRepository stickerStyle
//       , FontFamilyRepository fontFamily
//       , FontStyleRepository fontStyle
//       , IPushNotificationProvider notification
//        // , ChannelRepository channel
//         ) {
//         _privateMessage = privateMessage;
//         _publicMessage = publicMessage;
//         _privateArchive = privateArchive;
//         _publicArchive = publicArchive;
//         _context = context;
//         _frame = frame;
//         _frameOptions = frameOptions;
//         _user = user;
//         _settings = settings;
//         _stickerUrl = stickerUrl;
//         _stickerStyle = stickerStyle;
//         _fontFamily = fontFamily;
//         _fontStyle = fontStyle;
//         _notification = notification;
//         // _channel = channel;
//     }
//
//     public async Task<ValidationResult<PublicMessage>> SendPublicMessage(
//         PublicMessageDto dto) {
//         try {
//             var message = dto.Map() ?? throw new Exception("Cannot create a new message");
//             // var channels = new List<Channel>();
//             // foreach (var c in dto.ChannelIds ?? []) {
//             //     var channel = await _channel.FindById(c);
//             //     if (channel != null) channels.Add(channel);
//             // }
//             // message.Channels = channels;
//             
//             message = (await _publicMessage.Add(message)).ThrowIfInvalid().Value!;
//             (await _notification.SendNotification(new PublicMessageReceived(
//                     message.Content ?? string.Empty
//                   , new MessageMetadata {
//                         ContentType = message.ContentType ?? string.Empty
//                       , UserId = message.UserId ?? Guid.Empty
//                       , LandmarkId = message.LandmarkId ?? Guid.Empty
//                       , Position = message.Position
//                       , SentTime = message.Created
//                     })
//             )).ThrowIfInvalid();
//
//             return new(message);
//         } catch (Exception ex) { return new(ex); }
//     }
//
//     // public async Task<ValidationResult<PrivateMessage>> SendPrivateMessage(
//     //     PrivateMessageDto dto) { }
//
// #region Archive
//     public async Task<ValidationResult<PrivateArchive>> Archive(
//         ArchivePrivateMessageDto dto) {
//         try {
//             var message = await _privateMessage.FindById(dto.Id)
//              ?? throw new Exception("Message not found.");
//             await _privateMessage.Load(message, e => e.Reactions);
//             var user = await _user.Find(message.UserId);
//             if (user == null) throw new Exception("User not found.");
//             await _user.Load(user, u => u.MessageDecoration);
//             var decoration = GetUserDecoration(user.MessageDecoration);
//
//             //Create new object archive with data from dto and old message
//             var archive = dto.Map();
//             if (archive == null) throw new Exception("Cannot map dto to new archive.");
//             //Transfer data from message to archive
//             await HandleFrame(decoration, dto);
//             await HandleFont(decoration, dto);
//             //Handle unmapped properties from the dto
//             await HandleStickers(decoration, dto);
//             //Detach message
//             _context.Entry(message).State = EntityState.Detached;
//
//
//             archive.FrameId = decoration.FrameId;
//             archive.FrameOptionsId = decoration.FrameOptionsId;
//             archive.NoteFontFamilyId = decoration.FontFamilyId;
//             archive.NoteFontStyleId = decoration.FontStyleId;
//
//             //ADD new archived message
//             (await _privateArchive.Add(archive)).ThrowIfInvalid();
//             return new(archive);
//         } catch (Exception e) { return new(e); }
//     }
//
//     private async Task
//         HandleFont(MessageDecorationDto decoration, ArchiveMessageDto dto) {
//         var fontFamilyId = dto.FontFamily == null
//             ? _settings.Decoration.FontFamilyId
//             : (await _fontFamily.GetOrSet(dto.FontFamily)).Id;
//         var fontStyleId = dto.Style == null
//             ? _settings.Decoration.FontStyleId
//             : (await _fontStyle.GetOrSet(dto.Style, _settings.Curator)).Id;
//
//         decoration.FontFamilyId = fontFamilyId;
//         decoration.FontStyleId = fontStyleId;
//     }
//
//     private async Task HandleFrame(MessageDecorationDto decoration
//       , ArchiveMessageDto dto) {
//         var message = await _context.Messages.FindAsync(dto.Id);
//         var userDef = await _context.Set<UserMessageDecoration>()
//                                     .FindAsync(message?.UserId ?? Guid.Empty);
//         var defId = Guid.Empty;
//         if (Guid.TryParse(FrameOptions.DefaultId, out var defGuid)) defId = defGuid;
//
//         var def = await _context.FrameOptions.FindAsync(defId);
//         var frameName = dto.Frame?.FrameName ?? Frame.Default;
//         var frameId = (await _frame
//                              .Where(e => e.Name.Equals(frameName
//                                , StringComparison.OrdinalIgnoreCase))
//                              .FirstOrDefaultAsync())?.Id
//          ?? Guid.Parse(Frame.DefaultId);
//         var frameOptionsId = dto.Frame == null
//             ? _settings.Decoration.FrameOptionsId
//             : (await _frameOptions.GetOrSet(dto.Frame
//               , def
//               , FrameOptions.DefaultColorPrimary
//               , FrameOptions.DefaultColorSecondary
//               , userDef)).Id;
//
//         decoration.FrameId = frameId;
//         decoration.FrameOptionsId = frameOptionsId;
//     }
//
//     private async Task HandleStickers(MessageDecorationDto decoration
//       , ArchiveMessageDto dto) {
//         if (dto.Stickers == null) return;
//         List<(Guid Url, Guid Style)> stickers = new List<(Guid Url, Guid Style)>();
//         foreach (var sticker in dto.Stickers) {
//             var style = await _stickerStyle.GetOrSet(sticker.Position
//               , sticker.Size
//               , sticker.RotationDeg);
//             var url = await _stickerUrl.GetOrSet(sticker.StickerUrl);
//             stickers.Add((url.Id, style.Id));
//         }
//
//         decoration.Stickers.AddRange(stickers);
//     }
//
//     private MessageDecorationDto GetUserDecoration(UserMessageDecoration user) {
//         return new MessageDecorationDto {
//             FontFamilyId = user.NoteFontFamilyId ?? _settings.Decoration.FontFamilyId
//           , FontStyleId = user.NoteFontStyleId ?? _settings.Decoration.FontStyleId
//           , FrameId = user.FrameId ?? _settings.Decoration.FrameId
//           , FrameOptionsId = user.FrameOptionsId ?? _settings.Decoration.FrameOptionsId
//         };
//     }
//
//
//     public async Task<ValidationResult<PublicArchive>> Archive(
//         ArchivePublicMessageDto dto) {
//         try {
//             var message = await _privateMessage.FindById(dto.Id)
//              ?? throw new Exception("Message not found.");
//             await _privateMessage.Load(message, e => e.Reactions);
//             var user = await _user.Find(message.UserId);
//             if (user == null) throw new Exception("User not found.");
//             await _user.Load(user, u => u.MessageDecoration);
//             var decoration = GetUserDecoration(user.MessageDecoration);
//
//             //Create new object archive with data from dto and old message
//             var archive = dto.Map();
//             if (archive == null) throw new Exception("Cannot map dto to new archive.");
//             //Transfer data from message to archive
//             await HandleFrame(decoration, dto);
//             await HandleFont(decoration, dto);
//             //Handle unmapped properties from the dto
//             await HandleStickers(decoration, dto);
//             //Detach message
//             _context.Entry(message).State = EntityState.Detached;
//
//
//             archive.FrameId = decoration.FrameId;
//             archive.FrameOptionsId = decoration.FrameOptionsId;
//             archive.NoteFontFamilyId = decoration.FontFamilyId;
//             archive.NoteFontStyleId = decoration.FontStyleId;
//
//             //ADD new archived message
//             (await _publicArchive.Add(archive)).ThrowIfInvalid();
//             return new(archive);
//         } catch (Exception e) { return new(e); }
//     }
// #endregion
// }