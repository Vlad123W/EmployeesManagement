using EmployeesManagemant.Domain.Entities;
using EmployeesManagemant.Domain.Interfaces;
using EmployeesManagement.Application.Interfaces;
using AutoMapper;

namespace EmployeesManagement.Application.Services
{
    public class EmployeeService(IEmployeeRepository employeeRepository) : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository = employeeRepository;

        public Task<EmployeeDTO> CreateAsync(EmployeeDTO dto)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAllAsync()
        {
            var emplyees = await _employeeRepository.GetAllAsync();
            
            return emplyees.Select(empl => new EmployeeDTO
            {
                EmployeeId = empl.Id,
                FirstName = empl.FirstName,
                LastName = empl.LastName,
                Email = empl.Email,
                PhoneNumber = empl.PhoneNumber,
                HireDate = empl.HireDate,
                JobId = empl.JobId,
                Salary = empl.Salary,
                CommissionPct = empl.CommissionPct,
                ManagerId = empl.ManagerId,
                DepartmentId = empl.DepartmentId
            });
        }

        public Task<EmployeeDTO> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
