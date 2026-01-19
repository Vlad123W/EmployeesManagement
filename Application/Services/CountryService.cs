using EmployeesManagemant.Domain.Entities;
using EmployeesManagemant.Domain.Interfaces;
using EmployeesManagement.Application.Interfaces;

namespace EmployeesManagement.Application.Services
{
    public class CountryService(IGenericRepository<Country> countryRepository) : ICountryService
    {
        private readonly IGenericRepository<Country> _countryRepository = countryRepository;

        public async Task<CountryDTO> CreateAsync(CountryDTO dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto), "Country data cannot be null");
            }

            var countryEntity = new Country
            {
                Id = dto.CountryId,
                CountryName = dto.CountryName,
                RegionId = dto.RegionId
            };

            await _countryRepository.AddAsync(countryEntity);

            return dto;
        }

        public async Task<CountryDTO> DeleteAsync(string id)
        {
            var country = await _countryRepository.GetByIdAsync(id) 
                ?? throw new ArgumentNullException(nameof(id), "Country not found");
            
            await _countryRepository.Delete(country);

            return new CountryDTO
            {
                CountryId = country.Id,
                CountryName = country.CountryName,
                RegionId = country.RegionId
            };
        }

        public async Task<IEnumerable<CountryDTO>> GetAllAsync()
        {
            var countries = await _countryRepository.GetAllAsync();

            return countries.Select(x => new CountryDTO
            {
                CountryId = x.Id,
                CountryName = x.CountryName,
                RegionId = x.RegionId
            });
        }

        public async Task<CountryDTO> GetByIdAsync(string id)
        {
            var country = await _countryRepository.GetByIdAsync(id);

            return new CountryDTO
            {
                CountryId = country.Id,
                CountryName = country.CountryName,
                RegionId = country.RegionId
            };
        }

        public async Task<CountryDTO> UpdateAsync(string id, CountryDTO dto)
        {
            ArgumentNullException.ThrowIfNull(dto);

            await _countryRepository.Update(new Country
            {
                Id = id,
                CountryName = dto.CountryName,
                RegionId = dto.RegionId
            });

            return dto;
        }
    }
}
