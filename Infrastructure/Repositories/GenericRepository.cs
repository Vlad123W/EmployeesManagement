using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeesManagemant.Data;
using EmployeesManagemant.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EmployeesManagemant.Infrastructure.Repositories
{
    public class GenericRepository<T>(AppDbContext context) : IGenericRepository<T>, IDisposable where T : class
    {
        protected readonly AppDbContext _context = context;
        protected readonly DbSet<T> _dbSet = context.Set<T>();

        public async Task<T?> GetByIdAsync<TId>(TId id) => await _dbSet.FindAsync(id);

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

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
            if (from < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(from), "The 'from' parameter cannot be negative.");
            }

            if (count < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "The 'count' parameter must be at least 1.");
            }

            var total = await _dbSet.CountAsync();

            if (from >= total)
            {
                throw new ArgumentOutOfRangeException(nameof(from), "The 'from' parameter exceeds the number of entities.");
            }

            return await _dbSet.Skip(from).Take(count).ToListAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<int> GetLength() => await _dbSet.CountAsync();

        public async Task<T> GetLast()
        {
            var entityType = _context.Model.FindEntityType(typeof(T));
            
            var pkProperty = entityType?.FindPrimaryKey()?.Properties.FirstOrDefault();

            if (pkProperty != null)
            {
                string pkName = pkProperty.Name;
                return await _dbSet.OrderByDescending(e => EF.Property<object>(e, pkName)).FirstAsync();
            }

            return await _dbSet.LastAsync();
        }
    }
}