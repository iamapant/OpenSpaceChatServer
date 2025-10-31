using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Api.Database.Models;

[Table("Roles")]
public class Role {
    [Key]
    public Guid Id { get; set; }
    [Required, MaxLength(10)]
    public string Name { get; set; } = null!;
    
    public ICollection<User> Users { get; set; } = new List<User>();
}

public class RoleModelCreation:IModelCreationSettings<Role> {
    public void OnModelCreating(EntityTypeBuilder<Role> builder, ModelBuilder mb) {
        builder.Property(e => e.Id).HasValueGenerator<SequentialGuidValueGenerator>().ValueGeneratedOnAdd();
    }
}