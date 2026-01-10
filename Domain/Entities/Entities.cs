using System.Text.Json.Serialization;

namespace EmployeesManagemant.Domain.Entities
{
    public class Region : BaseEntity<int> 
    {
        public string? RegionName { get; set; }
        [JsonIgnore]
        public virtual ICollection<Country> Countries { get; set; } = [];
    }
    public class Country : BaseEntity<string> 
    {
        public string? CountryName { get; set; }
        public int? RegionId { get; set; }
        [JsonIgnore]
        public virtual ICollection<Location> Locations { get; set; } = [];
        [JsonIgnore]
        public virtual Region? Region { get; set; }
    }
    public class Location : BaseEntity<long> 
    {
        public string? StreetAddress { get; set; }
        public string? PostalCode { get; set; }
        public string City { get; set; } = null!;
        public string? StateProvince { get; set; }
        public string? CountryId { get; set; }
        [JsonIgnore]
        public virtual Country? Country { get; set; }
        [JsonIgnore]
        public virtual ICollection<Department> Departments { get; set; } = [];
    }
    public class Job : BaseEntity<string> 
    {
        public string JobTitle { get; set; } = null!;
        public decimal? MinSalary { get; set; }
        public decimal? MaxSalary { get; set; }
        [JsonIgnore]
        public virtual ICollection<Employee> Employees { get; set; } = [];
        [JsonIgnore]
        public virtual ICollection<JobHistory> JobHistories { get; set; } = [];
    }
    public class Department : BaseEntity<long>
    {
        public string DepartmentName { get; set; } = null!;
        public long? ManagerId { get; set; }
        public long? LocationId { get; set; }
        [JsonIgnore]
        public virtual ICollection<Employee> Employees { get; set; } = [];
        [JsonIgnore]
        public virtual ICollection<JobHistory> JobHistories { get; set; } = [];
        [JsonIgnore]
        public virtual Location? Location { get; set; }
        [JsonIgnore]
        public virtual Employee? Manager { get; set; }
    }
    public class Employee : BaseEntity<long> 
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateOnly HireDate { get; set; }
        public string? JobId { get; set; }
        public decimal? Salary { get; set; }
        public decimal? CommissionPct { get; set; }
        public long? ManagerId { get; set; }
        public long? DepartmentId { get; set; }
        [JsonIgnore]
        public virtual Department? Department { get; set; }
        [JsonIgnore]
        public virtual ICollection<Department> Departments { get; set; } = [];
        [JsonIgnore]
        public virtual ICollection<Employee> InverseManager { get; set; } = [];
        [JsonIgnore]
        public virtual Job? Job { get; set; }
        [JsonIgnore]
        public virtual ICollection<JobHistory> JobHistories { get; set; } = [];
        [JsonIgnore]
        public virtual Employee? Manager { get; set; }
    }
    public class JobHistory : BaseEntity<long>
    {
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string JobId { get; set; } = null!;
        public long? DepartmentId { get; set; }
        [JsonIgnore]
        public virtual Department? Department { get; set; }
        [JsonIgnore]
        public virtual Employee? Employee { get; set; }
        [JsonIgnore]
        public virtual Job? Job { get; set; }
    }
}