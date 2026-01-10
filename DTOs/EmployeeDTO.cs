namespace EmployeesManagement.DTOs
{
    public class EmployeeReadDTO
    {
        public long Id { get; set; }
        public string? FullName { get; set; } 
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateOnly HireDate { get; set; }
        public string? JobTitle { get; set; }
        public decimal Salary { get; set; }
        public string? DepartmentName { get; set; }
        public string? ManagerFullName { get; set; }
    }
}
