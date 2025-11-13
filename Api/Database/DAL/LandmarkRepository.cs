using System.Diagnostics;
using Api.Database;
using Api.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.DAL;

public class LandmarkRepository : DatabaseRepository<Landmark> {
    public LandmarkRepository(AppDbContext context) : base(context) { }
    public async Task<ICollection<Landmark>> GetByName(string name) {
        try {
            return await _entity
                         .Where(e => e.Name.Contains(name
                           , StringComparison.OrdinalIgnoreCase))
                         .ToListAsync();
        } catch (Exception ex) {
            Debug.WriteLine(ex);
            return [];
        }
    }

    public async Task<ICollection<Landmark>> GetByPosition(Position position, double range) {
        try {
            return await _entity
                         .Where(e => e.Position.DistanceTo(position) <= range)
                                .OrderBy(e => e.Position).ToListAsync();
        } catch (Exception ex) {
            Debug.WriteLine(ex);
            return [];
        }
    }
}