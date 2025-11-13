using Api.Database;
using Api.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.DAL;

public class RoleRepository : DatabaseRepository<Role> {
    public RoleRepository(AppDbContext context) : base(context) { }

    public async Task<Role?> GetByName(string name) {
        return await _entity.FirstOrDefaultAsync(e => e.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
    }

    public async Task<Role?> GetByUser(User user) {
        return await _entity.Include(e => e.Users)
                            .FirstOrDefaultAsync(e => e.Users.Contains(user));
    }
}