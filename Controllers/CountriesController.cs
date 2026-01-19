using EmployeesManagemant.Domain.Entities;
using EmployeesManagement.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController(ICountryService countryService) : ControllerBase
    {
        private readonly ICountryService _countryService = countryService;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _countryService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            if(string.IsNullOrEmpty(id))
            {
                return BadRequest("Country id is required.");
            }

            return Ok(await _countryService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CountryDTO dto)
        {
            if(dto == null)
            {
                return BadRequest("Country data is required.");
            }

            var createdCountry = await _countryService.CreateAsync(dto);
            return Ok(createdCountry);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] CountryDTO dto)
        {
            if(dto == null)
            {
                return BadRequest("Country data is required.");
            }

            var updatedCountry = await _countryService.UpdateAsync(id, dto);
            return Ok(updatedCountry);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if(string.IsNullOrEmpty(id))
            {
                return BadRequest("Country id is required.");
            }

            var deletedCountry = await _countryService.DeleteAsync(id);
            return Ok(deletedCountry);
        }
    }
}
