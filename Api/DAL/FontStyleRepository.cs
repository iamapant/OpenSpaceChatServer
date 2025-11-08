using Api.Database;
using Api.Database.Models;

namespace Api.DAL;

public class FontStyleRepository : DatabaseRepository<FontStyle> {
    public FontStyleRepository(AppDbContext context) : base(context) { }

    public async Task RemoveUnused(ILogger log) {
        try {
            _entity.RemoveRange(_entity.Where(e =>
                e.PrivateArchives.Count == 0 && e.PublicArchives.Count == 0
            ));
            await _context.SaveChangesAsync();
        } catch (Exception ex) { log.LogWarning(ex, "Could not remove unused font"); }
    }
}