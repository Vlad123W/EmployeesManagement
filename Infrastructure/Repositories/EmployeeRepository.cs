using EmployeesManagemant.Domain.Entities;
using EmployeesManagemant.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeesManagemant.Infrastructure.Repositories
{
    public class EmployeeRepository(DbContext context) : GenericRepository<Employee>(context), IEmployeeRepository
    {
        public async Task<IEnumerable<Employee>> GetEmployeesByDepartmentAsync(long departmentId)
        {
            return await _dbSet
                .Where(e => e.DepartmentId == departmentId)
                .ToListAsync();
        }

        public async Task<Employee?> GetWithDetailsAsync(long id)
        {
            return await _dbSet
                .Include(e => e.Job)
                .Include(e => e.Department)
                .Include(e => e.Manager)
                .Include(e => e.Department)
                .Include(e => e.JobHistories)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
