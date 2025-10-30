namespace Api.Database.Models;

public interface IArchive {
    //TODO: Customization options for archived message (frame type (polaroid, ), frame options, frame color, stickers, note, note font,... )
    MessageFrameType? FrameType { get; set; }
    Guid? FrameOptionsId { get; set; }
    MessageFrameOptions? FrameOptions { get; set; }
    //TODO: When a message is archived, if the message is not a text, the user
    //      can add a new note to it and then customize the note. If the message
    //      is a text, the text will be parsed as the note and then the user can
    //      customize it. 
    string? Note { get; set; }
    
    Guid? NoteFontStyleId { get; set; }
    FontStyle? NoteFontStyle { get; set; }
    
    Guid? NoteFontFamilyId { get; set; }
    FontFamily? NoteFontFamily { get; set; }
    ICollection<MessageStickerStyle>? Stickers { get; set; } 
}

public enum MessageFrameType {
    Polaroid,
    
}