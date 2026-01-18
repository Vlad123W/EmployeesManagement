using EmployeesManagemant.Domain.Entities;
using EmployeesManagemant.Domain.Interfaces;
using EmployeesManagement.Application.Interfaces;

namespace EmployeesManagement.Application.Services
{
    public class CountryService(IGenericRepository<Country> countryRepository) : ICountryService
    {
        private readonly IGenericRepository<Country> _countryRepository = countryRepository;

        public Task<CountryDTO> CreateAsync(CountryDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<CountryDTO> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CountryDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CountryDTO> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<CountryDTO> UpdateAsync(long id, CountryDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
