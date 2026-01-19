using EmployeesManagemant.Data;
using EmployeesManagemant.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace EmployeesManagemant.Infrastructure.Repositories
{
    public class GenericRepository<T>(AppDbContext context) : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context = context;
        protected readonly DbSet<T> _dbSet = context.Set<T>();

        public async Task<T?> GetByIdAsync<TId>(TId id) 
            => await _dbSet.FindAsync(id) ?? throw new ArgumentNullException(nameof(TId), $"No entities with {id} id found.");

        public async Task<IEnumerable<T>> GetAllAsync() 
            => await _dbSet.ToListAsync() ?? throw new ArgumentNullException(nameof(T), "No entities found.");

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity) 
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T entity) 
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetPartiallyAsync(int from, int count = 2)
        {
            int countOfEntities = _dbSet.Count();

            if (from - countOfEntities >= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(from), "The 'from' parameter exceeds the number of entities.");
            }

            if(count < 2)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "The 'count' parameter cannot be less than 2.");    
            }

            return await _dbSet.Skip(from).Take(count).ToListAsync();
        }
    }
}
