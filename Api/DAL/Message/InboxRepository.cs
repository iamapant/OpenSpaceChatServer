using Api.Database;
using Api.Database.Models;

namespace Api.DAL;

public class InboxRepository : DatabaseRepository<Inbox> {
    public InboxRepository(AppDbContext context) : base(context) { }
}