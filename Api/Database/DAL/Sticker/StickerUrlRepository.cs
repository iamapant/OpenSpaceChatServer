using Api.Database;
using Api.Database.Models;
using Api.Services;
using Microsoft.EntityFrameworkCore;

namespace Api.DAL;

public class StickerUrlRepository : DatabaseRepository<StickerUrl> {
    public StickerUrlRepository(AppDbContext context) : base(context) { }
    public async Task RemoveUnused(ILogger<CleanupService> log) {
        try {
            _entity.RemoveRange(_entity.Where(e =>
                e.ArchivedStickers.Count == 0
            ));
            await _context.SaveChangesAsync();
        } catch (Exception ex) { log.LogWarning(ex, "Could not remove unused font"); }
    }

    public async Task<StickerUrl> GetOrSet(string url) {
        var obj = await _entity.FirstOrDefaultAsync(e =>
            e.Url.Equals(url, StringComparison.OrdinalIgnoreCase));
        if (obj == null) {
            obj = new StickerUrl {
                Url = url.ToLowerInvariant(),
            };
            await _entity.AddAsync(obj);
            await _context.SaveChangesAsync();
        }
        return obj;
    }
}