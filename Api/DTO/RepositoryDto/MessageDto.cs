using System.ComponentModel.DataAnnotations;
using System.Drawing;
using Api.Database;
using Api.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.DTO;

public class MessageDto {
    [Required]
    public string UserId { get; set; } = null!;

    [Required, MaxLength(20)]
    public string? ContentType { get; set; }

    [MaxLength(500)]
    public string? Content { get; set; }

    public Position Position { get; set; }
    public string? LandmarkId { get; set; }
}

public class PrivateMessageDto : MessageDto, IAddDto<PrivateMessage> {
    [Required]
    public string InboxId { get; set; } = null!;

    public PrivateMessage? Map() {
        if (!Guid.TryParse(UserId, out var userId)
         || !Guid.TryParse(InboxId, out var inboxId)) return null;
        var lid = Guid.Empty;
        if (LandmarkId != null) {
            if (Guid.TryParse(LandmarkId, out var landmarkId)) lid = landmarkId;
        }

        return new PrivateMessage {
            Id = Message.GetId(UserId, Position)
          , UserId = userId
          , InboxId = inboxId
          , ContentType = ContentType
          , Content = Content
          , Latitude = Position.Latitude
          , Longitude = Position.Longitude
          , LandmarkId = lid
        };
    }
}

public class ArchivePrivateMessageDto : IAddDto<PrivateArchive> {
    [Required]
    public string Id { get; set; } = null!;

    [Required]
    public string ArchivedUserId { get; set; } = null!;

    public bool IsPublic { get; set; } = true;
    public string? Note { get; set; }
    public MessageFrameDto? Frame { get; set; }
    public FontStyleDto? Style { get; set; }
    public string? FontFamily { get; set; }
    public ICollection<ArchiveStickerDto>? Stickers { get; set; }

    public PrivateArchive? Map() {
        if (!Guid.TryParse(ArchivedUserId, out var archivedUserId)) return null;
        return new PrivateArchive {
            Id = Id
          , ArchivedUserId = archivedUserId
          , IsPublic = IsPublic
          , Note = Note
        };
    }


    // public async Task MapMessage(PrivateArchive archive
    //   , PrivateMessage msg
    //   , AppDbContext ctx) {
    //     archive.Id = msg.Id;
    //     archive.UserId = msg.UserId;
    //     archive.ContentType = msg.ContentType;
    //     archive.Content = msg.Content;
    //     archive.Created = msg.Created;
    //     archive.Latitude = msg.Position.Latitude;
    //     archive.Longitude = msg.Position.Longitude;
    //     archive.LandmarkId = msg.LandmarkId;
    //     archive.InboxId = msg.InboxId;
    //     archive.PinnedDmId = msg.PinnedDmId;
    //     archive.Reactions = msg.Reactions.Select(r
    //                                => new MessageReaction() {
    //                                    MessageId = r.MessageId
    //                                  , UserId = r.UserId
    //                                  , Reaction = r.Reaction
    //                                  , Created = r.Created
    //                                })
    //                            .ToList();
    //     //Frame
    //     if (Frame != null) {
    //         //Type
    //         var frame = await ctx.MessageFrames.FindAsync(Frame.FrameId);
    //         if (frame == null) {
    //             archive.FrameId = frame?.Id ?? Guid.Parse(MessageFrame.DefaultId);
    //         }
    //
    //         //Options
    //         Color? primaryColor = Frame.PrimaryColorArgb.HasValue
    //             ? Color.FromArgb(Frame.PrimaryColorArgb.Value)
    //             : null;
    //         Color? secondaryColor = Frame.SecondaryColorArgb.HasValue
    //             ? Color.FromArgb(Frame.SecondaryColorArgb.Value)
    //             : null;
    //
    //         var fOptions = await ctx.Frames.FirstOrDefaultAsync(o =>
    //             o.ColorPrimary == primaryColor && o.ColorSecondary == secondaryColor);
    //         if (fOptions != null) {
    //             
    //         }
    //         else 
    //     }
    // }
}

public class PublicMessageDto : MessageDto, IAddDto<PublicMessage> {
    public PublicMessage? Map() {
        if (!Guid.TryParse(UserId, out var userId)) return null;
        var lid = Guid.Empty;
        if (LandmarkId != null) {
            if (Guid.TryParse(LandmarkId, out var landmarkId)) lid = landmarkId;
        }

        return new PublicMessage {
            Id = Message.GetId(UserId, Position)
          , UserId = userId
          , ContentType = ContentType
          , Content = Content
          , Latitude = Position.Latitude
          , Longitude = Position.Longitude
          , LandmarkId = lid
        };
    }
}

public class ArchivePublicMessageDto : IAddDto<PublicArchive> {
    [Required]
    public string Id { get; set; } = null!;
    [Required]
    public string UserId { get; set; } = null!;

    [Required]
    public string ArchivedUserId { get; set; } = null!;

    public string? Note { get; set; }
    public MessageFrameDto? Frame { get; set; }
    public FontStyleDto? Style { get; set; }
    public string? FontFamily { get; set; }
    public ICollection<StickerDto>? Stickers { get; set; }

    public PublicArchive? Map() {
        if (!Guid.TryParse(ArchivedUserId, out var archivedUserId)
         || !Guid.TryParse(UserId, out var userId)) return null;
        return new PublicArchive { UserId = userId, Note = Note };
        // ***Make sure to config other fields as well
    }
    // public async Task MapMessage(PublicArchive archive
    //   , PublicMessage msg
    //   , AppDbContext ctx) {
    //     archive.Id = msg.Id;
    //     archive.UserId = msg.UserId;
    //     archive.ContentType = msg.ContentType;
    //     archive.Content = msg.Content;
    //     archive.Created = msg.Created;
    //     archive.Latitude = msg.Position.Latitude;
    //     archive.Longitude = msg.Position.Longitude;
    //     archive.LandmarkId = msg.LandmarkId;
    //     archive.Reactions = msg.Reactions.Select(r
    //                                => new MessageReaction() {
    //                                    MessageId = r.MessageId
    //                                  , UserId = r.UserId
    //                                  , Reaction = r.Reaction
    //                                  , Created = r.Created
    //                                })
    //                            .ToList();
    //     //Frame
    //     if (Frame != null) {
    //         //Type
    //         var frame = await ctx.MessageFrames.FindAsync(Frame.FrameId);
    //         if (frame == null) {
    //             archive.FrameId = frame?.Id ?? Guid.Parse(MessageFrame.DefaultId);
    //         }
    //
    //         //Options
    //         Color? primaryColor = Frame.PrimaryColorArgb.HasValue
    //             ? Color.FromArgb(Frame.PrimaryColorArgb.Value)
    //             : null;
    //         Color? secondaryColor = Frame.SecondaryColorArgb.HasValue
    //             ? Color.FromArgb(Frame.SecondaryColorArgb.Value)
    //             : null;
    //
    //         var fOptions = await ctx.Frames.FirstOrDefaultAsync(o =>
    //             o.ColorPrimary == primaryColor && o.ColorSecondary == secondaryColor);
    //         if (fOptions != null) {
    //             
    //         }
    //     }
    // }
}