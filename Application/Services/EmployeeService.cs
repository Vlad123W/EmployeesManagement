using EmployeesManagemant.Domain.Entities;
using EmployeesManagemant.Domain.Interfaces;
using EmployeesManagement.Application.Interfaces;
using AutoMapper;

namespace EmployeesManagement.Application.Services
{
    public class EmployeeService(IEmployeeRepository employeeRepository) : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository = employeeRepository;

        public async Task<EmployeeDTO> CreateAsync(EmployeeDTO dto)
        {
            ArgumentNullException.ThrowIfNull(dto);

            var employee = new Employee
            {
                Id = dto.EmployeeId,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                HireDate = dto.HireDate,
                ManagerId = dto.ManagerId,
                DepartmentId = dto.DepartmentId
            };

            await _employeeRepository.AddAsync(employee);

            return dto;
        }

        public async Task<EmployeeDTO> DeleteAsync(long id)
        {
            var emplyee = await _employeeRepository.GetByIdAsync(id) 
                ?? throw new KeyNotFoundException($"Employee with id {id} not found.");
            
            await _employeeRepository.Delete(emplyee);
            
            return new EmployeeDTO
            {
                EmployeeId = emplyee.Id,
                FirstName = emplyee.FirstName,
                LastName = emplyee.LastName,
                HireDate = emplyee.HireDate,
                ManagerId = emplyee.ManagerId,
                DepartmentId = emplyee.DepartmentId
            };
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAllAsync()
        {
            var emplyees = await _employeeRepository.GetAllAsync();
            
            return emplyees.Select(empl => new EmployeeDTO
            {
                FirstName = empl.FirstName,
                LastName = empl.LastName,
                HireDate = empl.HireDate,
                ManagerId = empl.ManagerId,
                DepartmentId = empl.DepartmentId
            });
        }

        public async Task<EmployeeDTO> GetByIdAsync(long id)
        {
            var emplyee = await _employeeRepository.GetByIdAsync(id);

            return new EmployeeDTO
            {
                FirstName = emplyee!.FirstName,
                LastName = emplyee.LastName,
                HireDate = emplyee.HireDate,
                ManagerId = emplyee.ManagerId,
                DepartmentId = emplyee.DepartmentId
            };
        }

        public async Task<EmployeeDTO> UpdateAsync(long id, EmployeeDTO dto)
        {
            await _employeeRepository.Update(new Employee
            {
                Id = dto.EmployeeId,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                HireDate = dto.HireDate,
                ManagerId = dto.ManagerId,
                DepartmentId = dto.DepartmentId
            });

            return dto;
        }
    }
}
