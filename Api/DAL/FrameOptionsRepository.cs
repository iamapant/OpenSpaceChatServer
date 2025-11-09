using Api.Database;
using Api.Database.Models;

namespace Api.DAL;

public class FrameOptionsRepository : DatabaseRepository<FrameOptions> {
    public FrameOptionsRepository(AppDbContext context) : base(context) { }
}