using Microsoft.AspNetCore.Mvc;
using EmployeesManagemant.Domain.Entities;
using EmployeesManagement.Application.Interfaces;

namespace EmployeesManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var employees = await _employeeService.GetAllAsync();

            if (employees == null) return NotFound(employees);

            return Ok(employees);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var employee = await _employeeService.GetByIdAsync(id);

            if (employee == null) return BadRequest(employee);

            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmployeeDTO employee)
        {
            if(employee == null) return BadRequest(employee);

            return Ok(await _employeeService.CreateAsync(employee));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] EmployeeDTO employee)
        {
            if(employee == null) return BadRequest(employee);

            return Ok(await _employeeService.UpdateAsync(id, employee));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(await _employeeService.GetByIdAsync(id) == null) return NotFound(id);

            return Ok(await _employeeService.DeleteAsync(id));
        }
    }
}
