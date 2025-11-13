namespace Api.DTO;

public class NewUserDto { }
public class RemoveUserDto {
    public string UserId { get; set; }
    public bool IsSoftDelete { get; set; }
    public TimeSpan? SoftDeleteOverride { get; set; } 
}