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

        // GET api/<EmployeesController>/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok();
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Employee employee)
        {
            return Ok();
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
