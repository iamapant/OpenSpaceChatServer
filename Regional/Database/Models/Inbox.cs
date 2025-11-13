using System.ComponentModel.DataAnnotations;

namespace Regional.Database.Models;

public class Inbox {
    [Key]
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public ICollection<Guid> UserIds { get; set; } = new List<Guid>();
}