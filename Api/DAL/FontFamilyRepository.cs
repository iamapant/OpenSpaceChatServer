using Api.Database;
using Api.Database.Models;

namespace Api.DAL;

public class FontFamilyRepository : DatabaseRepository<FontFamily> {
    public FontFamilyRepository(AppDbContext context) : base(context) { }

    public async Task RemoveUnused(ILogger log) {
        try {
            _entity.RemoveRange(_entity.Where(e =>
                e.PrivateArchives.Count == 0 && e.PublicArchives.Count == 0
            ));
            var affected = await _context.SaveChangesAsync();
            log.LogInformation($"Removed {affected} unused font families");
        } catch (Exception ex) { log.LogWarning(ex, "Could not remove unused font families"); }
    }
}