using EmployeesManagemant.Domain.Entities;

namespace EmployeesManagement.Application.Interfaces
{
    public interface IGenericService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> CreateAsync(T dto);
    }
}
