namespace Api.DTO;

public struct MessageMetadata {
    public Guid UserId { get; set; }
    public DateTime SentTime {get; set;}
    public Position Position {get; set;}
    public string ContentType {get; set;}
    public Guid LandmarkId {get; set;} 
}