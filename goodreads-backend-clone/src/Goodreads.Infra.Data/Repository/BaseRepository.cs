using System.Data;
using Goodreads.Core.Entities;
using Goodreads.Core.Interfaces.Repository;
using Goodreads.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Goodreads.Infra.Data.Repository;

public class BaseRepository<E, T> : IBaseRepository<E, Guid> where E : BaseEntity
{
    private readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }

    protected internal async Task Commit() =>
        await _context.SaveChangesAsync();

    public async Task Rollback() =>
        await (await _context.Database
                .BeginTransactionAsync(IsolationLevel.ReadCommitted))
            .RollbackAsync();
    
    public async Task<IEnumerable<E>> GetAsync() =>
        await _context.Set<E>().ToListAsync();

    public async Task<E> GetByIdAsync(Guid id)
    {
        try
        {
            var entity = await _context.Set<E>().FindAsync(id);
            if (entity != null)
                return entity;
            else
                return null;
        }
        catch (Exception ex)
        {
            throw ex.InnerException;
        }
    }

    public async Task<E> AddAsync(E entity)
    {
        try
        {
            entity.Id = Guid.NewGuid();
            entity.CreatedAt = DateTime.UtcNow;

            _context.Set<E>().Add(entity);
        }
        catch (Exception ex)
        {
            await Rollback();
            throw ex.InnerException;
        }

        await Commit();
        return entity;
    }

    public async Task<E> UpdateAsync(E entity)
    {
        try
        {
            var result = await GetByIdAsync(entity.Id);
            if (result == null) return null;

            entity.UpdatedAt = DateTime.UtcNow;
            entity.CreatedAt = result.CreatedAt;

            _context.Entry(result).CurrentValues.SetValues(entity);
        }
        catch (Exception ex)
        {
            await Rollback();
            throw ex.InnerException;
        }

        await Commit();
        return entity;
    }

    public async Task<bool> RemoveAsync(Guid id)
    {
        try
        {
            var result = await GetByIdAsync(id);
            if (result == null) return false;

            _context.Set<E>().Remove(result);
        }
        catch (Exception ex)
        {
            await Rollback();
            throw ex.InnerException;
        }

        await Commit();
        return true;
    }
}