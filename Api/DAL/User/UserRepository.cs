using System.Diagnostics;
using System.Text.RegularExpressions;
using Api.Database;
using Api.Database.Models;
using Api.DTO;
using Api.Hashing;
using Api.Providers;
using Api.Providers.Token;
using Microsoft.EntityFrameworkCore;

namespace Api.DAL;

public class UserRepository : DatabaseRepository<User> {
    private RefreshTokenProvider _refresh;
    private DbSet<UserBlacklist> _blacklist;
    private GlobalSettings _globalSettings;

    public UserRepository(RefreshTokenProvider refresh, AppDbContext context, GlobalSettings globalSettings) :
        base(context) {
        _refresh = refresh;
        _globalSettings = globalSettings;
        _blacklist = context.Set<UserBlacklist>();
    }

    //Get user
    public async ValueTask<User?> GetByEmail(string email
      , UserInfoRepository userInfoRepository) {
        var info = await userInfoRepository.GetByEmail(email);
        if (info == null) return null;

        return await FindById(info.ToString()!);
    }

    public async Task<User?> GetByUsername(string username) {
        return await _entity.FirstOrDefaultAsync(e => e.Name.Equals(username
                                                   , StringComparison
                                                         .OrdinalIgnoreCase));
    }

    public override async Task<ValidationResult> Delete(object key
      , params object?[]? additionalKeys) {
        try {
            var entity = await Find(ConcatKeys(key, additionalKeys));
            if (entity == null)
                throw new
                    InvalidOperationException($"{nameof (User)} not found.");

            entity.IsDeleted = DateTime.UtcNow;
            return await Update(entity);
        } catch (Exception ex) { return new ValidationResult(ex, this); }
    }

    public override async Task<ValidationResult> Remove(User entity) {
        try {
            entity.IsDeleted = DateTime.UtcNow;
            return await Update(entity);
        } catch (Exception ex) { return new ValidationResult(ex, this); }
    }

    public async Task<ValidationResult> ChangeActiveStatus(string id
      , bool? active = null) {
        try {
            var user = await FindById(id);
            if (user == null) throw new InvalidOperationException($"User not found.");
            
            if (active == user.IsActive)
                throw new
                    InvalidOperationException("Current active state is already set.");

            user.IsActive = active ?? !user.IsActive;
            await Save(user);
        } catch (Exception ex) { return new(ex); }

        return new();
    }
    

    public async Task DeleteExpiredUsers(ILogger log) {
        try {
            var users = _entity.Where(e => e.IsDeleted != null && e.IsDeleted.Value.AddHours(_globalSettings.Admin.SoftDeleteRetentionInHours) <= DateTime.UtcNow);
            _entity.RemoveRange(users);
            var affected = await _context.SaveChangesAsync();
            log.LogInformation($"Removed {affected} deleted users.");
        }catch (Exception ex) {
            log.LogError(ex, "Could not remove expired users.");
        }
    }

    public async Task<User?> FindByName(string name) {
        return await _entity.FirstOrDefaultAsync(e => name.Equals(e.Name
          , StringComparison.OrdinalIgnoreCase));
    }
}