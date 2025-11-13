using System.Diagnostics;
using Api.Database;
using Api.Database.Models;
using Api.DTO;
using Microsoft.EntityFrameworkCore;

namespace Api.DAL;

public class UserBlacklistRepository : DatabaseRepository<UserBlacklist> {
    public UserBlacklistRepository(AppDbContext context) : base(context) { }

    public async Task<ICollection<UserBlacklist>> GetBlacklist(string id) {
        if (!Guid.TryParse(id, out var guid)) return [];
        return await _entity
                     .Where(b => b.UserId == guid)
                     .ToListAsync();
    }

    public async Task<ICollection<User>> GetBlacklistedBy(string id) {
        if (!Guid.TryParse(id, out var guid)) return [];
        return await _entity.Where(e => e.BlacklistId == guid)
                            .Select(e => e.User)
                            .ToListAsync();
    }

    public async Task RemoveTimeoutBlacklist(ILogger log) {
        try {
            var timeout = _entity
                .Where(e => e.Temporary && e.Until <= DateTime.UtcNow);
            if (!timeout.Any()) return;

            _context.RemoveRange(timeout.ToList());
            var affected = await _context.SaveChangesAsync();
            log.LogInformation($"Removed {affected} timeout blacklists.");
        }catch (Exception ex) {
            log.LogError(ex, "Could not remove timeout blacklists.");
        }
    }
}