using System.Diagnostics;
using Api.Database;
using Api.DTO;
using Microsoft.EntityFrameworkCore;

namespace Api.DAL;

public abstract class DatabaseRepository {
    protected AppDbContext _context { get; }

    public DatabaseRepository(AppDbContext context) {
        _context = context;
    }
}

public abstract class DatabaseRepository<T> : DatabaseRepository
    where T : class {
    protected DbSet<T> _entity { get; }

    protected DatabaseRepository(AppDbContext context) : base(context) {
        _entity = context.Set<T>();
    }

    public virtual async Task<ICollection<T>> GetAll() {
        return await _entity.ToListAsync();
    }

    public virtual async ValueTask<T?> FindById(string id) {
        return await _entity.FindAsync(Guid.Parse(id));
    }

    public virtual async Task<ValidationResult> Add(IAddDto<T> dto) {
        try {
            var entity = dto.Map();
            if (entity == null) throw new InvalidOperationException($"Cannot map to {typeof(T).Name}.");
            
            var entry = await _entity.AddAsync(entity);
            if (entry.State != EntityState.Added) throw new InvalidOperationException("Expected Added state after Add().");
            
            var affected = await _context.SaveChangesAsync();
            if (affected == 0) throw new InvalidOperationException("No records were saved.");
            if (entry.State != EntityState.Unchanged) throw new InvalidOperationException($"{typeof(T).Name} not in Unchanged state after save.");
        }
        catch (Exception ex) {
            return new ValidationResult(ex, this);
        }

        return new();
    }

    public virtual async Task<ValidationResult> Update(string id, IUpdateDto<T> dto) {
        try {
            var entity = await FindById(id);
            if (entity == null) throw new InvalidOperationException($"{typeof(T).Name} not found.");
            
            TransferData(entity, dto);
            
            var entry = _entity.Update(entity);
            var affected = await _context.SaveChangesAsync();
            if (affected == 0) throw new InvalidOperationException("No records were updated.");
        }
        catch (Exception ex) {
            return new ValidationResult(ex, this);
        }
        return new();
    }
    
    protected abstract void TransferData(T existing, IUpdateDto<T> dto);

    public virtual async Task<ValidationResult> Delete(string id) {
        try {
            var entity = await FindById(id);
            if (entity == null) throw new InvalidOperationException($"{typeof(T).Name} not found.");

            _entity.Remove(entity);
            var affected = await _context.SaveChangesAsync();
            if (affected == 0) throw new InvalidOperationException("No records were deleted.");
        }
        catch (Exception ex) {
            return new ValidationResult(ex, this);
        }
        return new();
        
    }
}