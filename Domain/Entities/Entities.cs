using Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text;

namespace EmployeesManagemant.Domain.Entities
{
    public class Region : BaseEntity<int> 
    {
        public string? RegionName { get; set; }

        public ICollection<Country> Countries { get; set; } = [];
    }

    public class Country : BaseEntity<string> 
    {
        public string? CountryName { get; set; }
        public int RegionId { get; set; }

        public Region? Region { get; set; }
        public ICollection<Location> Locations { get; set; } = [];
    }

    public class Location : BaseEntity<long> 
    {
        public string? StreetAddress { get; set; }
        public string? PostalCode { get; set; }
        public string City { get; set; } = null!;
        public string? StateProvince { get; set; }
        public long CountryId { get; set; }

        public Country? Country { get; set; }
        public ICollection<Department> Departments { get; set; } = [];
    }

    public class Department : BaseEntity<long>
    {
        public string DepartmentName { get; set; } = null!;
        public int? ManagerId { get; set; } 
        public long? LocationId { get; set; }

        public Location? Location { get; set; }
        public Employee? Manager { get; set; }
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
   
    public class Job : BaseEntity<string> 
    {
        public string JobTitle { get; set; } = null!;
        public decimal? MinSalary { get; set; }
        public decimal? MaxSalary { get; set; }

        public ICollection<Employee> Employees { get; set; } = [];
    }

    public class Employee : BaseEntity<long> 
    {
        public string? FirstName { get; set; }
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public DateOnly HireDate { get; set; } 
        public string JobId { get; set; } = null!;
        public decimal Salary { get; set; }
        public decimal? CommissionPct { get; set; }
        public int? ManagerId { get; set; }
        public long? DepartmentId { get; set; }

 
        public Job Job { get; set; } = null!;
        public Department? Department { get; set; }
        public Employee? Manager { get; set; }
        public ICollection<Employee> Subordinates { get; set; } = new List<Employee>();
        public ICollection<Vacation> Vacations { get; set; } = new List<Vacation>();
        public ICollection<JobHistory> JobHistories { get; set; } = new List<JobHistory>();
    }

    public class JobHistory
    {
        public int EmployeeId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string JobId { get; set; } = null!;
        public int DepartmentId { get; set; }

        public Employee Employee { get; set; } = null!;
        public Job Job { get; set; } = null!;
        public Department Department { get; set; } = null!;
    }

    public class Vacation : BaseEntity<int> 
    {
        public int EmployeeId { get; set; }
        public DateOnly VacationStartDate { get; set; }
        public DateOnly VacationEndDate { get; set; }

        public Employee Employee { get; set; } = null!;
    }
}