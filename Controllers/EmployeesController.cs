using Microsoft.AspNetCore.Mvc;
using EmployeesManagemant.Domain.Interfaces;
using EmployeesManagemant.Domain.Entities;
using EmployeesManagement.Application.Interfaces;

namespace EmployeesManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesManagementController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesManagementController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

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
            return Ok(await _employeeService.CreateAsync(employee));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] EmployeeDTO employee)
        {
            return Ok(await _employeeService.UpdateAsync(id, employee));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _employeeService.DeleteAsync(id));
        }
    }
}
