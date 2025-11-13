using System.Diagnostics;
using Api.Database;
using Api.Database.Models;

namespace Api.DAL;

public class UserTimeoutRepository : DatabaseRepository<UserTimeout> {
    public UserTimeoutRepository(AppDbContext context) : base(context) { }

    public async Task RemoveExpiredTimeouts(ILogger log) {
        try {
            var timeouts = _entity.Where(e => e.TimeoutEnd <= DateTime.UtcNow);
            _entity.RemoveRange(timeouts);
            var affected = await _context.SaveChangesAsync();
            log.LogInformation($"Removed {affected} expired timeouts");
        } catch (Exception e) {
            log.LogWarning(e,  "Could not remove expired timeouts");
        }
    }
}