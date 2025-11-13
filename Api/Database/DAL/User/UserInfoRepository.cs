using Api.Database;
using Api.Database.Models;
using Api.DTO;
using Microsoft.EntityFrameworkCore;

namespace Api.DAL;

public class UserInfoRepository : DatabaseRepository<UserInfo> {
    public UserInfoRepository(AppDbContext context) : base(context) { }
    public async Task<Guid?> GetByEmail(string email) {
        return (await _entity.FirstOrDefaultAsync(e => email.Equals(e.Email, StringComparison.OrdinalIgnoreCase)))?.Id;
    }

    public async Task<Guid?> GetByPhone(string phone) {
        return (await _entity.FirstOrDefaultAsync(e => phone.Equals(e.Phone, StringComparison.OrdinalIgnoreCase)))?.Id;
    }

    public async Task<ICollection<Guid>> GetByBirthday(DateTime date) {
        return await _entity.Where(e => e.DoB == date).Select(e => e.Id).ToListAsync();
    }

    public async Task<ICollection<Guid>> GetByBirthYear(int year) {
        return await _entity.Where(e => e.DoB.Year == year).Select(e => e.Id).ToListAsync();
    }
}