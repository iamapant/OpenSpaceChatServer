using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using Api.Database.Models;
using Api.Hashing;
using Api.Providers.Hashing;

namespace Api.DTO;

public class UserAddDto : IAddDto<User> {
    public string Name { get; set; } = null!;
    public string Password { get; set; } = null!;
    public Guid RoleId { get; set; }

    public User? Map() {
        try {
            return new User {
                Name = Name
                , PasswordHash = Hasher.Current.Hash(Password)
                , IsActive = true
                , RoleId = RoleId
            };
        } catch { return null; }
    }
}

public class CreateAccountDto : IAddDto<User> {
    [Required, EmailAddress, MaxLength(255)]
    public string Email { get; set; } = null!;
    [Phone]
    public string? Phone { get; set; } 
    [Required,  MaxLength(30)]
    public string Username { get; set; } = null!;
    [Required, MaxLength(50)]
    public string FirstName { get; set; } = null!;
    [MaxLength(100)]
    public string? LastName { get; set; }
    [MaxLength(50)]
    public string? DisplayName { get; set; }
    [Required]
    public DateTime DoB { get; set; }
    [MaxLength(2)]
    public string? CountryCode { get; set; }
    public User? Map() {
        return new User {
            Name = Username,
            IsActive = true,
            UserInfo = new UserInfo {
                Email = Email,
                Phone = Phone,
                FirstName = FirstName,
                LastName = LastName,
                DisplayName = DisplayName,
                DoB = DoB,
                CountryCode = CountryCode,
            }
        };
    }
} 
public class UserUsernameChangeDto : IUpdateDto<User> {
    [Required]
    public string Id { get; set; } = null!;
    [Required, MaxLength(30)]
    public string Name { get; set; } = null!;
    public void Map(User entity) {
        entity.Name = Name;
    }
}

public class CreateAccountMailDto {
    public string Id { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Email { get; set; } = null!;
    public JwtSecurityToken Jwt { get; set; }  = null!;
}

public class UserPasswordChangeDto : IUpdateDto<User> {
    [Required]
    public string Id { get; set; } = null!;
    [Required, MaxLength(260)]
    public string NewPassword { get; set; } = null!;

    public void Map(User entity) {
        entity.PasswordHash = Hasher.Current.Hash(NewPassword);
    }
} 