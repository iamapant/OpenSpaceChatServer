using System.ComponentModel.DataAnnotations;
using Api.Database.Models;

namespace Api.DTO;

public class StickerDto : IAddDto<StickerStyle> {
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
    public StickerStyle? Map() {
        if (StickerUrl == string.Empty) return null;
        if (!Guid.TryParse(MessageId,  out var messageId)) return null;
    
        return new StickerStyle() {
            PositionX = Position.Longitude
          , PositionY = Position.Latitude
          , Width = Size.Longitude
          , Height = Size.Latitude
          , Rotation = RotationDeg 
        };
    }
}

public class ArchiveStickerDto{
    [Required, MaxLength(2048)]
    public string StickerUrl { get; set; } = string.Empty;
    [Required]
    public Position Position {get; set;} 
    [Required]
    public Position Size {get; set;}
    [Required]
    public float RotationDeg { get; set; }
}