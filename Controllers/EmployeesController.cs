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
        public async Task<IEnumerable<EmployeeDTO>> Get()
        {
            return await _employeeService.GetAllAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<EmployeeDTO> Get(int id)
        {
            return await _employeeService.GetByIdAsync(Convert.ToInt64(id));
        }

        [HttpPost]
        public async Task<EmployeeDTO> Post([FromBody] EmployeeDTO employee)
        {
            return await _employeeService.CreateAsync(employee);
        }

        [HttpPut("{id:int}")]
        public async Task<bool> Put(int id, [FromBody] EmployeeDTO employee)
        {
            return await _employeeService.UpdateAsync(id, employee);
        }

        [HttpDelete("{id:int}")]
        public async Task<EmployeeDTO> Delete(int id)
        {
            return await _employeeService.DeleteAsync(id);
        }
    }
}
