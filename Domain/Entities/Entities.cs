using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text;

namespace EmployeesManagemant.Domain.Entities
{
    public class Region : BaseEntity<int> 
    {
        public string? RegionName { get; set; }
        public virtual ICollection<Country> Countries { get; set; } = [];
    }
    public class Country : BaseEntity<string> 
    {
        public string? CountryName { get; set; }
        public int? RegionId { get; set; }
        public virtual ICollection<Location> Locations { get; set; } = [];
        public virtual Region? Region { get; set; }
    }
    public class Location : BaseEntity<long> 
    {
        public string? StreetAddress { get; set; }
        public string? PostalCode { get; set; }
        public string City { get; set; } = null!;
        public string? StateProvince { get; set; }
        public string? CountryId { get; set; }
        public virtual Country? Country { get; set; }
        public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
    }
    public class Job : BaseEntity<string> 
    {
        public string JobTitle { get; set; } = null!;
        public decimal? MinSalary { get; set; }
        public decimal? MaxSalary { get; set; }
        public virtual ICollection<Employee> Employees { get; set; } = [];
        public virtual ICollection<JobHistory> JobHistories { get; set; } = [];
    }
    public class Department : BaseEntity<long>
    {
        public string DepartmentName { get; set; } = null!;
        public long? ManagerId { get; set; }
        public long? LocationId { get; set; }
        public virtual ICollection<Employee> Employees { get; set; } = [];
        public virtual ICollection<JobHistory> JobHistories { get; set; } = [];
        public virtual Location? Location { get; set; }
        public virtual Employee? Manager { get; set; }
    }
    public class Employee : BaseEntity<long> 
    {
        public string? FirstName { get; set; }
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public DateOnly HireDate { get; set; }
        public string JobId { get; set; } = null!;
        public decimal? Salary { get; set; }
        public decimal? CommissionPct { get; set; }
        public long? ManagerId { get; set; }
        public long? DepartmentId { get; set; }
        public virtual Department? Department { get; set; }
        public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
        public virtual ICollection<Employee> InverseManager { get; set; } = new List<Employee>();
        public virtual Job Job { get; set; } = null!;
        public virtual ICollection<JobHistory> JobHistories { get; set; } = new List<JobHistory>();
        public virtual Employee? Manager { get; set; }
    }
    public class JobHistory : BaseEntity<long>
    {
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string JobId { get; set; } = null!;
        public long? DepartmentId { get; set; }
        public virtual Department? Department { get; set; }
        public virtual Employee Employee { get; set; } = null!;
        public virtual Job Job { get; set; } = null!;
    }
}