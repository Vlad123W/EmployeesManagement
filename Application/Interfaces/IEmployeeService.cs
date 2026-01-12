using EmployeesManagemant.Domain.Entities;

namespace EmployeesManagement.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDTO>> GetAllAsync();
        Task<EmployeeDTO> GetByIdAsync(long id);
        Task<EmployeeDTO> CreateAsync(EmployeeDTO dto);
    }
}
