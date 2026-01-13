using System.Text.Json.Serialization;

namespace EmployeesManagemant.Domain.Entities
{
    public class RegionDTO
    {
        public int RegionId { get; set; }
        public string? RegionName { get; set; }
    }

    public class CountryDTO 
    {
        public string? CountryId { get; set; }
        public string? CountryName { get; set; }
        public int? RegionId { get; set; }
    }

    public class LocationDTO 
    {
        public long LocationId { get; set; }
        public string? StreetAddress { get; set; }
        public string? PostalCode { get; set; }
        public string City { get; set; } = null!;
        public string? StateProvince { get; set; }
        public string? CountryId { get; set; }
    }

    public class JobDTO
    {
        public string? JobId { get; set; }
        public string? JobTitle { get; set; }
        public decimal? MinSalary { get; set; }
        public decimal? MaxSalary { get; set; }
    }

    public class DepartmentDTO
    {
        public long DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public long? ManagerId { get; set; }
        public long? LocationId { get; set; }
    }

    public class EmployeeDTO
    {
        public long EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateOnly HireDate { get; set; }
        public long? ManagerId { get; set; }
        public long? DepartmentId { get; set; }
    }

    public class JobHistoryDTO
    {
        public long EmployeeId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string? JobId { get; set; }
        public long? DepartmentId { get; set; }
    }
}