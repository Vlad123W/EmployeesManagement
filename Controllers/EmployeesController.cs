using Microsoft.AspNetCore.Mvc;
using EmployeesManagemant.Domain.Interfaces;
using System.Threading.Tasks;

namespace EmployeesManagemant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesManagementController(IUnitOfWork unitOfWork) : ControllerBase
    {
        public readonly IUnitOfWork _unitOfWork = unitOfWork;

        [HttpGet]
        public async Task<IEnumerable<object>> Get()
        {
            return await _unitOfWork.Regions.GetAllAsync();
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
