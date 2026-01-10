using EmployeesManagemant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesManagemant.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetByIdAsync<TId>(TId id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetPartiallyAsync(int from, int count);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }

    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<IEnumerable<Employee>> GetEmployeesByDepartmentAsync(long departmentId);
        Task<Employee?> GetWithDetailsAsync(long id);
    }
   
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        Task<IEnumerable<Department>> GetDepartmentsByLocationAsync(long locationId);
    }

    public interface IJobHistoryRepository : IGenericRepository<JobHistory>
    {
        Task<IEnumerable<JobHistory>> GetByEmployeeIdAsync(long employeeId);
    }
   
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository Employees { get; }
        IGenericRepository<Job> Jobs { get; }
        IDepartmentRepository Departments { get; }
        IJobHistoryRepository JobHistory { get; }
        IGenericRepository<Country> Countries { get; }
        IGenericRepository<Location> Locations { get; }
        IGenericRepository<Region> Regions { get; }

        Task<int> SaveChangesAsync();
    }
}
