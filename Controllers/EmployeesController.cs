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
            var employees = await _employeeService.GetAllAsync();
            
            if(!employees.Any())
            {
                return NotFound("No employees found.");
            }
            
            return Ok(employees);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _employeeService.GetByIdAsync(id);
            
            if (result == null)
            {
                return NotFound($"Incorrect id: {id}.");
            }
            
            return Ok(result);
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
            var result = await _employeeService.DeleteAsync(id);

            if (result == null)
            {
                return NotFound($"Incorrect id: {id}.");
            }

            return Ok(result);
        }
    }
}
