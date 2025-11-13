using Api.Database;
using Api.Database.Models;
using Api.DTO;
using Microsoft.EntityFrameworkCore;

namespace Api.DAL;
public class PrivateMessageRepository : DatabaseRepository<PrivateMessage> {
    public PrivateMessageRepository(AppDbContext context) : base(context) { }
}