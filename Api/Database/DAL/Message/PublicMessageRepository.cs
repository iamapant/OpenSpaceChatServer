using Api.Database;
using Api.Database.Models;

namespace Api.DAL;

public class PublicMessageRepository : DatabaseRepository<PublicMessage> {
    public PublicMessageRepository(AppDbContext context) : base(context) { }
}