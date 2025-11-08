using Api.Database;
using Api.Database.Models;
using Api.DTO;
using Microsoft.EntityFrameworkCore;

namespace Api.DAL;
public class PrivateMessageRepository : DatabaseRepository<PrivateMessage> {
    public PrivateMessageRepository(AppDbContext context) : base(context) { }

    [Send this function to services]
    public async Task<ValidationResult<PrivateArchive>> Archive(IAddDto<PrivateArchive> dto) {
        try {
            if (dto is not ArchivePrivateMessageDto d) throw new Exception($"Dto must be {typeof(ArchivePrivateMessageDto)}");
            var message = await FindById(d.Id) ?? throw new Exception("Message not found.")
            //Detach message
            _context.Entry(message).State = EntityState.Detached;
            //Create new object archive with data from dto and old message
            var archive = d.Map();
            if (archive == null) throw new Exception("Cannot map dto to new archive.");
            await d.MapMessage(archive, message, _context);
            //ADD new archived message
            
            _context.Set<PrivateArchive>().Add(archive);
            await _context.SaveChangesAsync();
        } catch (Exception e) { return new(e); }
    }
}