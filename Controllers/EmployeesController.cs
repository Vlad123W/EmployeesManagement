using Microsoft.AspNetCore.Mvc;
using EmployeesManagemant.Domain.Interfaces;
using EmployeesManagemant.Domain.Entities;

namespace EmployeesManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesManagementController(IUnitOfWork unitOfWork) : ControllerBase
    {
        public readonly IUnitOfWork _unitOfWork = unitOfWork;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _unitOfWork.Employees.GetPartiallyAsync(5, 10));
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _unitOfWork.Employees.GetWithDetailsAsync(Convert.ToInt64(id)));
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Employee employee)
        {
            if (employee == null) return BadRequest("Data is null");

            await _unitOfWork.Employees.AddAsync(employee);

            return CreatedAtAction(nameof(Post), new {id = employee.Id });
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
