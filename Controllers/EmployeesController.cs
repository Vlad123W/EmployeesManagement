using Microsoft.AspNetCore.Mvc;
using EmployeesManagemant.Domain.Entities;
using EmployeesManagement.Application.Interfaces;
using FluentValidation;

namespace EmployeesManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController(IEmployeeService employeeService, IValidator<EmployeeDTO> validator) : ControllerBase
    {
        private readonly IEmployeeService _employeeService = employeeService;
        private readonly IValidator<EmployeeDTO> _validator = validator;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _employeeService.GetAllAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _employeeService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmployeeDTO employee)
        {
            var validationResult = await _validator.ValidateAsync(employee);
            
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            return Ok(await _employeeService.CreateAsync(employee));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] EmployeeDTO employee)
        {
            var validationResult = await _validator.ValidateAsync(employee);
            
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            return Ok(await _employeeService.UpdateAsync(id, employee));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _employeeService.DeleteAsync(id));
        }
    }
}
