using Microsoft.EntityFrameworkCore;
using ProductsCleanArch.Domain.Entities;
using ProductsCleanArch.Domain.Interfaces.Repository;
using ProductsCleanArch.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsCleanArch.Infra.Data.Repository
{
    public class BaseRepository<E, T> : IBaseRepository<E, int> where E : BaseEntity
    {
        private readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        protected internal async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<E>> GetAsync()
        {
            try
            {
                return await _context.Set<E>().ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<E> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _context.Set<E>().SingleOrDefaultAsync(x => x.Id == id);
                if (entity != null)
                    return entity;
                else
                    return null;
            }
            catch
            {
                throw;
            }
        }

        public async Task<E> AddAsync(E entity)
        {
            try
            {
                entity.CreatedAt = DateTime.UtcNow;

                _context.Set<E>().Add(entity);
                await Commit();
            }
            catch
            {
                return null;
            }

            return entity;
        }

        public async Task<E> UpdateAsync(E entity)
        {
            try
            {
                var result = await GetByIdAsync(entity.Id);
                if (result == null)
                    return null;

                entity.UpdatedAt = DateTime.UtcNow;
                entity.CreatedAt = result.CreatedAt;

                _context.Entry(result).CurrentValues.SetValues(entity);
                await Commit();
            }
            catch
            {
                throw;
            }

            return entity;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            try
            {
                var result = await GetByIdAsync(id);
                if (result == null)
                    return false;

                _context.Set<E>().Remove(result);
                await Commit();
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
