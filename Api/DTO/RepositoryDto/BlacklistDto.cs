using System.ComponentModel.DataAnnotations;
using Api.Database.Models;

namespace Api.DTO;

public class BlacklistDto : IAddDto<UserBlacklist>, IUpdateDto<UserBlacklist> {
    [Required]
    public string UserId { get; set; } = null!;

    [Required]
    public string BlacklistId { get; set; } = null!;
    
    public DateTime? Until { get; set; }

    public UserBlacklist? Map() {
        if (!Guid.TryParse(UserId, out var userGuid)
            || !Guid.TryParse(BlacklistId, out var blacklistGuid)) return null;
        return new UserBlacklist {
            UserId = userGuid
          , BlacklistId = blacklistGuid
          , Until = this.Until ?? DateTime.MaxValue
          , Temporary = Until != null
        };
    }

    public void Map(UserBlacklist entity) {
        entity.Temporary = Until != null;
        entity.Until = Until ?? DateTime.MaxValue;
    }
}

public class DeBlacklistDto {
    [Required]
    public string UserId { get; set; } = null!;

    [Required]
    public string BlacklistId { get; set; } = null!;
}