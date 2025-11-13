using System.ComponentModel.DataAnnotations.Schema;

namespace Regional.Database.Models;

[Table("Roles")]
public class Role {
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<User> Users { get; set; } = new List<User>();
}