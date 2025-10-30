using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Database.Models;

[Table("UserInfos")]
public class UserInfo {
    [Key, ForeignKey(nameof(User))]
    public Guid Id { get; set; }
    
    
    [Required, EmailAddress, MaxLength(50)]
    public string Email { get; set; } = null!;
    [Phone,  MaxLength(15)]
    public string? Phone { get; set; }
    [Required, MaxLength(50)]
    public string FirstName { get; set; } = null!;
    [MaxLength(100)]
    public string? LastName { get; set; }
    [MaxLength(50)]
    public string? DisplayName { get; set; }
    [MaxLength(512)]
    public string? Bio { get; set; }
    [Required]
    public DateTime DoB { get; set; }
    [MaxLength(2048)]
    public string? AvatarUrl { get; set; }
    [MaxLength(2048)]
    public string? CoverUrl { get; set; }
    [MaxLength(60)]
    public string? Country { get; set; }
    
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime Updated { get; set; }

    public User User { get; set; } = null!; 
}