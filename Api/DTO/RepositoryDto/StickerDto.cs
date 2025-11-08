using System.ComponentModel.DataAnnotations;
using Api.Database.Models;

namespace Api.DTO;

public class StickerDto{
    [Required]
    public string MessageId { get; set; } = null!;
    [Required, MaxLength(2048)]
    public string StickerUrl { get; set; } = string.Empty;
    [Required]
    public Position Position {get; set;} 
    [Required]
    public Position Size {get; set;}
    [Required]
    public float RotationDeg { get; set; }
    // public MessageStickerStyle? Map() {
    //     if (StickerUrl == string.Empty) return null;
    //     if (!Guid.TryParse(MessageId,  out var messageId)) return null;
    //
    //     return new MessageStickerStyle() {
    //         PositionX = (Position ?? default).Longitude
    //       , PositionY = (Position ?? default).Latitude
    //       , Width = (Size ?? default).Longitude
    //       , Height = (Size ?? default).Latitude
    //       , Rotation = RotationDeg ?? 0
    //     };
    // }
}