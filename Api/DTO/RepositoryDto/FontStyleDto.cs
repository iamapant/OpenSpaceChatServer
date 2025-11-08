using System.ComponentModel.DataAnnotations;
using Api.Database.Models;

namespace Api.DTO;

public class FontStyleDto : IUpdateDto<FontStyle> {
    public int? Weight { get; set; }
    [MaxLength(15)]
    public string? Style { get; set; }      //Italic, oblique
    public float? SizeInPx { get; set; }
    public float? LetterSpacing { get; set; }
    public float? LineSpacing { get; set; }
    [MaxLength(50)]
    public string? TextDecoration { get; set; }     //Underline, overline, strikethrough
    [MaxLength(10)]
    public string? TextTransform  { get; set; }     //Uppercase, lowercase

    public void Map(FontStyle entity) {
        if (Weight.HasValue) entity.Weight = Weight.Value;
        if (Style != null) entity.Style = Style;
        if (SizeInPx.HasValue) entity.SizeInPx = SizeInPx.Value;
        if (LetterSpacing.HasValue) entity.LetterSpacing = LetterSpacing.Value;
        if (LineSpacing.HasValue) entity.LineSpacing = LineSpacing.Value;
        if (TextDecoration != null) entity.TextDecoration = TextDecoration;
        if (TextTransform != null) entity.TextTransform = TextTransform;
    }
}