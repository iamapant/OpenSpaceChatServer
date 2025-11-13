using System.Collections;
using System.Diagnostics;
using System.Linq.Expressions;
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

    public async Task Load<TProperty>(T entity, Expression<Func<T, IEnumerable<TProperty>>> collection)
        where TProperty : class {
        await _context.Entry(entity)
                      .Collection(collection)
                      .LoadAsync();
    }

    public async Task Load<TProperty>(T entity, Expression<Func<T, TProperty?>> collection)
        where TProperty : class {
        await _context.Entry(entity)
                      .Reference(collection)
                      .LoadAsync();
    }

    public virtual async Task<ICollection<T>> GetAll() {
        return await _entity.ToListAsync();
    }
    
    public virtual async Task<ICollection<T>> ToList(Expression<Func<T, bool>> predicate) 
    => await Where(predicate).ToListAsync();

    public IQueryable<T> Where(Expression<Func<T, bool>> expression) {
        return _entity.Where(expression);
    }

    public virtual async Task ForEach(
        Expression<Func<T, bool>> predicate
      , Action<T> action
      , CancellationToken ct) 
        => await _entity.Where(predicate).ForEachAsync(action, ct);

    public virtual async Task ForEach(
        Action<T> action
      , CancellationToken ct) 
        => await _entity.ForEachAsync(action, ct);


    public virtual async ValueTask<T?> FindById(string id) {
        return await _entity.FindAsync(Guid.Parse(id));
    }

    public virtual async ValueTask<T?> Find(params object?[]? id) {
        return await _entity.FindAsync(id);
    }

    public virtual async Task<ValidationResult<T>> Add(IAddDto<T> dto) {
        try {
            var entity = dto.Map();
            if (entity == null) throw new InvalidOperationException($"Cannot map to {typeof(T).Name}.");

            var entry = await _entity.AddAsync(entity);
            if (entry.State != EntityState.Added) throw new InvalidOperationException("Expected Added state after Add().");
            
            var affected = await _context.SaveChangesAsync();
            if (affected == 0) throw new InvalidOperationException("No records were saved.");
            if (entry.State != EntityState.Unchanged) throw new InvalidOperationException($"{typeof(T).Name} not in Unchanged state after save.");
            
            return new(entity);
        }
        catch (Exception ex) {
            return new (ex, this);
        }
    }

    public virtual async Task<ValidationResult<T>> Add(T entity) {
        try {
            var entry = await _entity.AddAsync(entity);
            if (entry.State != EntityState.Added) throw new InvalidOperationException("Expected Added state after Add().");
            
            var affected = await _context.SaveChangesAsync();
            if (affected == 0) throw new InvalidOperationException("No records were saved.");
            if (entry.State != EntityState.Unchanged) throw new InvalidOperationException($"{typeof(T).Name} not in Unchanged state after save.");

            return new(entity);
        }
        catch (Exception ex) {
            return new (ex, this);
        }
    }

    public virtual async Task<ValidationResult<T>> Update(T entity) {
        try {
            await Save(entity);
            return new(entity);
        }
        catch (Exception ex) {
            return new (ex, this);
        }
    }
    
    protected object?[]? ConcatKeys(object? key, object?[]? additionalKeys) {
        var keys = new List<object?>();
        keys.Add(key);
        keys.AddRange(additionalKeys ?? []);
        return keys.ToArray();
    }

    public virtual async Task<ValidationResult<T>> Update(IUpdateDto<T> dto, string id) {
        try {
            var entity = await FindById(id);
            if (entity == null) throw new InvalidOperationException($"{typeof(T).Name} not found.");
            
            dto.Map(entity);
            
            await Save(entity);
            return new(entity);
        }
        catch (Exception ex) {
            return new (ex, this);
        }
    }
    
    /// <summary>
    /// Un-safe method to save an entity to database 
    /// </summary>
    /// <param name="entity">The entity to save</param>
    /// <param name="message">Exception message when the operation failed</param>
    /// <exception cref="InvalidOperationException">Thrown when cannot save entity to database</exception>
    protected async Task Save(T entity, string? message = null) {
        _entity.Update(entity);
        var affected = await _context.SaveChangesAsync();
        if (affected < 1) throw new InvalidOperationException(message ?? $"No records were updated.");
    }
    
    /// <summary>
    /// Find and Remove an entity from database using its key(s). Use <see cref="Remove"/> instead to remove using reference. 
    /// </summary>
    /// <param name="key">The key of the object.</param>
    /// <param name="additionalKeys">Any additional key to compose the key of the object.</param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException">Thrown when cannot remove entity from database</exception>
    public virtual async Task<ValidationResult> Delete(object key, params object?[]? additionalKeys) {
        try {
            var entity = await Find(ConcatKeys(key, additionalKeys));
            if (entity == null) throw new InvalidOperationException($"{typeof(T).Name} not found.");

            return await Remove(entity);
        }
        catch (Exception ex) {
            return new ValidationResult(ex, this);
        }
    }

    /// <summary>
    /// Find and Remove an entity from database
    /// </summary>
    /// <param name="entity">The entity to remove</param>
    /// <returns>Fail with exception message if failed to remove entity.</returns>
    /// <exception cref="InvalidOperationException">Thrown when cannot remove entity from database</exception>
    public virtual async Task<ValidationResult> Remove(T entity) {
        try {
            _entity.Remove(entity);
            var affected = await _context.SaveChangesAsync();
            if (affected == 0)
                throw new InvalidOperationException("No records were deleted.");
        } catch (Exception ex) {
            return new ValidationResult(ex, this);
        }
        return new();
    }
}