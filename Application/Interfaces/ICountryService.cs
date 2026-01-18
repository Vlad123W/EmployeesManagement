using EmployeesManagemant.Domain.Entities;

namespace EmployeesManagement.Application.Interfaces
{
    public interface ICountryService : IGenericService<CountryDTO>
    {
        Task<CountryDTO> GetByIdAsync(string id);
    }
}
