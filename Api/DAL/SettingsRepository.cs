using Api.Database;
using Api.Database.Models;
using Api.DTO;

namespace Api.DAL;

public class SettingsRepository : DatabaseRepository {
    public SettingsRepository(AppDbContext context) : base(context) { }

    public async Task<ValidationResult<CuratorSettings>> UpdateCuratorSettings(CuratorSettingsDto dto) {
        try {
            var settings = await _context.CuratorSettings.FindAsync(1);
            if (settings == null) throw new Exception("Curator settings not found");
            
            dto.Map(settings);
            _context.CuratorSettings.Update(settings);
            var affected = await _context.SaveChangesAsync();
            if (affected < 1) throw new Exception("Could not update curator settings");
            return new (settings);
        } catch (Exception ex) { return new(ex); }
    }
    public async Task<ValidationResult<AdminSettings>> UpdateAdminSettings(AdminSettingsDto dto) { 
        try {
            var settings = await _context.AdminSettings.FindAsync(1);
            if (settings == null) throw new Exception("Curator settings not found");
            
            dto.Map(settings);
            _context.AdminSettings.Update(settings);
            var affected = await _context.SaveChangesAsync();
            if (affected < 1) throw new Exception("Could not update curator settings");
            return new (settings);
        } catch (Exception ex) { return new(ex); }
    }
}