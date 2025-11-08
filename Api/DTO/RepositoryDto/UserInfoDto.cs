using System.ComponentModel.DataAnnotations;
using Api.Database.Models;

namespace Api.DTO;

public class UserInfoDto : IUpdateDto<UserInfo> {
    [Required]
    public string Id { get; set; } = null!;
    [Phone,  MaxLength(15)]
    public string? Phone { get; set; }
    public string? FirstName { get; set; }
    [MaxLength(100)]
    public string? LastName { get; set; }
    [MaxLength(50)]
    public string? DisplayName { get; set; }
    [MaxLength(512)]
    public string? Bio { get; set; }
    public DateTime? DoB { get; set; }
    [MaxLength(2048)]
    public string? AvatarUrl { get; set; }
    [MaxLength(2048)]
    public string? CoverUrl { get; set; }
    [MaxLength(2)]
    public string? CountryCode { get; set; }

    public void Map(UserInfo entity) {
        if (Phone != null) entity.Phone = Phone;
        if (FirstName != null) entity.FirstName = FirstName;
        if (LastName != null) entity.LastName = LastName;
        if (DisplayName != null) entity.DisplayName = DisplayName;
        if (Bio != null) entity.Bio = Bio;
        if (AvatarUrl != null) entity.AvatarUrl = AvatarUrl;
        if (CoverUrl != null) entity.CoverUrl = CoverUrl;
        if (CountryCode != null) entity.CountryCode = CountryCode;
        if (DoB != null) entity.DoB = DoB.Value;
    }
}



public class UserEmailChangeDto : IUpdateDto<User> {
    [Required]
    public string Id { get; set; } = null!;
    [Required, EmailAddress, MaxLength(255)]
    public string Email { get; set; } = null!;
    public void Map(User entity) {
        entity.Name = Email;
    }
}
