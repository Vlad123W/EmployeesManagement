using EmployeesManagemant.Domain.Entities;

namespace EmployeesManagement.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDTO>> GetAllAsync();
        Task<EmployeeDTO> GetByIdAsync(long id);
        Task<IEnumerable<EmployeeDTO>> GetAllAsync(int countOfEmployees);
        Task<EmployeeDTO> CreateAsync(EmployeeDTO dto);
        Task<EmployeeDTO> UpdateAsync(long id, EmployeeDTO dto);
        Task<EmployeeDTO> DeleteAsync(long id);
    }
}
