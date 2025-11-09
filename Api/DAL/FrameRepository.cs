using Api.Database;
using Api.Database.Models;

namespace Api.DAL;

public class FrameRepository : DatabaseRepository<Frame> {
    public FrameRepository(AppDbContext context) : base(context) { }
}