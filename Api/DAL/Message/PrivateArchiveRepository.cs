using Api.Database;
using Api.Database.Models;

namespace Api.DAL;

public class PrivateArchiveRepository : DatabaseRepository<PrivateArchive> {
    public PrivateArchiveRepository(AppDbContext context) : base(context) { }
}