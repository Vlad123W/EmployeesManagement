using EmployeesManagemant.Data;
using EmployeesManagemant.Domain.Entities;
using EmployeesManagemant.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeesManagemant.Infrastructure.Repositories
{
    public class JobHistoryRepository(AppDbContext context) 
                : GenericRepository<JobHistory>(context), IJobHistoryRepository
    {
        public async Task<IEnumerable<JobHistory>> GetByEmployeeIdAsync(long employeeId)
            => await _dbSet.Where(x => x.Id == employeeId).ToListAsync();
    }
}
