using System.ComponentModel.DataAnnotations;
using Api;
using Regional.Database.Models;

namespace Regional.DTO;

public class NewUserDto : IAddDto<User> {
    [Required]
    public string Id { get; set; } = null!;

    [Required]
    public string RoleId { get; set; } = null!;

    [Required]
    public Position Position { get; set; }


    public User? Map() {
        if (!Guid.TryParse(Id, out var userId)
         || !Guid.TryParse(RoleId, out var roleId)) return null;
        return new User {
            Id = userId
          , RoleId = roleId
          , LastActive = DateTime.UtcNow
          , Latitude = Position.Latitude
          , Longitude = Position.Longitude
        };
    }
}

public class VoteTimeoutUserDto {
    [Required]
    public string Id { get; set; } = null!;
    [Required]
    public string TimeoutUserId { get; set; } = null!;
    [Required]
    public VoteOptions VoteOptions { get; set; } 
}

public enum VoteOptions {
    Yes,
    No,
    Abstain
}