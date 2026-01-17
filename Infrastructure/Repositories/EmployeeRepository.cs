using EmployeesManagemant.Data;
using EmployeesManagemant.Domain.Entities;
using EmployeesManagemant.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeesManagemant.Infrastructure.Repositories
{
    public class EmployeeRepository(AppDbContext context) : GenericRepository<Employee>(context), IEmployeeRepository
    {
        public async Task<IEnumerable<Employee>> GetEmployeesByDepartmentAsync(long departmentId)
        {
            return await _dbSet
                .Where(e => e.DepartmentId == departmentId)
                .ToListAsync();
        }
    }
}
