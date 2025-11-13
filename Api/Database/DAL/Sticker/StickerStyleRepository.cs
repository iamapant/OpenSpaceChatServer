using Api.Database;
using Api.Database.Models;
using Api.Services;
using Microsoft.EntityFrameworkCore;

namespace Api.DAL;

public class StickerStyleRepository : DatabaseRepository<StickerStyle> {
    public StickerStyleRepository(AppDbContext context) : base(context) { }
    public async Task RemoveUnused(ILogger<CleanupService> log) {
        try {
            _entity.RemoveRange(_entity.Where(e =>
                e.ArchivedStickers.Count == 0
            ));
            await _context.SaveChangesAsync();
        } catch (Exception ex) { log.LogWarning(ex, "Could not remove unused font"); }
    }

    public async Task<StickerStyle> GetOrSet(Position position, Position size, float rotation) {
        var obj = await _entity.FirstOrDefaultAsync(e =>
            e.Position == position && e.Size == size && Math.Abs(rotation - e.Rotation) < 0.000000001);
        if (obj == null) {
            obj = new StickerStyle {
                PositionX = position.Longitude,
                PositionY = position.Latitude,
                Width = size.Longitude,
                Height = size.Latitude,
                Rotation = rotation,
            };
            await _entity.AddAsync(obj);
            await _context.SaveChangesAsync();
        }
        return obj;
    }
}