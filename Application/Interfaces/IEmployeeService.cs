using EmployeesManagemant.Domain.Entities;

namespace EmployeesManagement.Application.Interfaces
{
    public interface IEmployeeService : IGenericService<EmployeeDTO>
    {
        Task<IEnumerable<EmployeeDTO>> GetAllAsync(int countOfEmployees);
        Task<EmployeeDTO> GetByIdAsync(long id);
        Task<EmployeeDTO> DeleteAsync(long id);
        Task<EmployeeDTO> UpdateAsync(long id, EmployeeDTO dto);
    }
}
