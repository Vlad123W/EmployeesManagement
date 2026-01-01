using EmployeesManagemant.Domain.Entities;
using EmployeesManagemant.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeesManagemant.Infrastructure.Repositories
{
    public class DepartmentRepository(DbContext context) : GenericRepository<Department>(context), IDepartmentRepository
    {
        public async Task<IEnumerable<Department>> GetDepartmentsByLocationAsync(long locationId)
            => await _dbSet.Where(x => x.LocationId == locationId).ToListAsync();
    }
}
