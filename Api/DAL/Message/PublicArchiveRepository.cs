using Api.Database;
using Api.Database.Models;

namespace Api.DAL;

public class PublicArchiveRepository : DatabaseRepository<PublicArchive> {
    public PublicArchiveRepository(AppDbContext context) : base(context) { }
}