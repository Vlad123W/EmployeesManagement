using EmployeesManagemant.Domain.Entities;
using EmployeesManagemant.Domain.Interfaces;
using EmployeesManagemant.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

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
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
