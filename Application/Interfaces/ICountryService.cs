using EmployeesManagemant.Domain.Entities;

namespace EmployeesManagement.Application.Interfaces
{
    public interface ICountryService : IGenericService<CountryDTO>
    {
        Task<CountryDTO> UpdateAsync(string id, CountryDTO dto);
        Task<CountryDTO> DeleteAsync(string id);
        Task<CountryDTO> GetByIdAsync(string id);
    }
}
