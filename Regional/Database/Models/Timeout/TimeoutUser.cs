using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Regional.Database.Models.Timeout;

public class TimeoutUser {
    [Key, ForeignKey(nameof(User))]
    public Guid Id { get; set; }
    public DateTime Until { get; set; } 
    public User User { get; set; } = null!;
}