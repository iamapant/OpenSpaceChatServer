using System.Diagnostics;
using Api.Database;
using Api.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.DAL;

public class SupportTicketRepository : DatabaseRepository<SupportTicket> {
    public SupportTicketRepository(AppDbContext context) : base(context) { }

    public async Task<ICollection<SupportTicket>> Get(string? userId = null
      , string? title = null
      , string? keyword = null
      , string? type = null
      , string? tags = null) {
        try {
            var list = _entity.AsQueryable();
            if (userId != null) {
                if (!Guid.TryParse(userId, out var id))
                    throw new Exception("Invalid user id.");
                list = list.Where(e => e.UserId == id);
            }

            if (title != null) {
                list =  list.Where(e => e.Title.Contains(title,  StringComparison.OrdinalIgnoreCase));
            }

            return await list.ToListAsync();
        } catch (Exception ex) {
            Debug.WriteLine(ex);
            return [];
        }
    }
}