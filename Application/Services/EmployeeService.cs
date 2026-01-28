using EmployeesManagemant.Domain.Entities;
using EmployeesManagemant.Domain.Interfaces;
using EmployeesManagement.Application.Interfaces;
using AutoMapper;

namespace EmployeesManagement.Application.Services
{
    public class EmployeeService(IEmployeeRepository employeeRepository) : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository = employeeRepository;

        /// <summary>
        /// Creates a new employee
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Returns the created employee DTO</returns>
        public async Task<EmployeeDTO> CreateAsync(EmployeeDTO dto)
        {
            var employee = new Employee
            {
                Id = (await _employeeRepository.GetLast()).Id + 1,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                HireDate = dto.HireDate,
                ManagerId = dto.ManagerId,
                DepartmentId = dto.DepartmentId
            };

            await _employeeRepository.AddAsync(employee);

            return dto;
        }

        /// <summary>
        /// Gets an id of the employee to delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns>If id is greater than the number of employees, returns null; otherwise, returns the deleted employee's DTO.</returns>
        public async Task<EmployeeDTO> DeleteAsync(long id)
        {
            var emplyee = await _employeeRepository.GetByIdAsync(id);
            
            if(emplyee == null) return null;
            
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

        /// <summary>
        /// Gets all the employees in database
        /// </summary>
        /// <returns>Returns IEnumerable<EmployeeDTO> of EmployeeDTO if succesful, otherwise an empty collection.</returns>
        public async Task<IEnumerable<EmployeeDTO>> GetAllAsync()
        {
            var emplyees = await _employeeRepository.GetAllAsync();
            
            if(!emplyees.Any()) return [];

            return emplyees.Select(empl => new EmployeeDTO
            {
                EmployeeId = empl.Id,
                FirstName = empl.FirstName,
                LastName = empl.LastName,
                HireDate = empl.HireDate,
                ManagerId = empl.ManagerId,
                DepartmentId = empl.DepartmentId
            });
        }

        /// <summary>
        /// Gets a specified number of employees from the database
        /// </summary>
        /// <param name="countOfEmployees">The number of employees to retrieve</param>
        /// <returns>Returns IEnumerable<EmployeeDTO> of EmployeeDTO if successful, otherwise an empty collection.</returns>
        public async Task<IEnumerable<EmployeeDTO>> GetAllAsync(int countOfEmployees)
        {
            var emplyees = await _employeeRepository.GetAllAsync();

            ArgumentNullException.ThrowIfNull(emplyees);

            return emplyees.Take(countOfEmployees).Select(empl => new EmployeeDTO
            {
                EmployeeId = empl.Id,
                FirstName = empl.FirstName,
                LastName = empl.LastName,
                HireDate = empl.HireDate,
                ManagerId = empl.ManagerId,
                DepartmentId = empl.DepartmentId
            }).Take(countOfEmployees);
        }

        /// <summary>
        /// Gets specified employee by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns the employee DTO if found; otherwise, null.</returns>
        public async Task<EmployeeDTO> GetByIdAsync(long id)
        {
            var emplyee = await _employeeRepository.GetByIdAsync(id);
            
            if (emplyee == null) return null;
            
            return new EmployeeDTO
            {
                EmployeeId = emplyee!.Id,
                FirstName = emplyee!.FirstName,
                LastName = emplyee.LastName,
                HireDate = emplyee.HireDate,
                ManagerId = emplyee.ManagerId,
                DepartmentId = emplyee.DepartmentId
            };
        }
        
        /// <summary>
        /// Gets an id and dto of the employee to update
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns>Updated employee DTO if successful; otherwise, null.</returns>
        public async Task<EmployeeDTO> UpdateAsync(long id, EmployeeDTO dto)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            
            if(employee == null) return null;
            if(dto == null) return null;
            if(id != dto.EmployeeId) return null;

            employee.FirstName = dto.FirstName;
            employee.LastName = dto.LastName;
            employee.HireDate = dto.HireDate;
            employee.DepartmentId = dto.DepartmentId;
            employee.ManagerId = dto.ManagerId;

            await _employeeRepository.Update(employee);

            return new EmployeeDTO
            {
                EmployeeId = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                HireDate = employee.HireDate,
                ManagerId = employee.ManagerId,
                DepartmentId = employee.DepartmentId
            };
        }
    }
}
