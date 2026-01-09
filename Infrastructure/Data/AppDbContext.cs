using System;
using System.Collections.Generic;
using EmployeesManagemant.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeesManagemant.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<JobHistory> JobHistories { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Region> Regions { get; set; }
   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("countries_pkey");

            entity.ToTable("countries");

            entity.Property(e => e.Id)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("country_id");
            entity.Property(e => e.CountryName)
                .HasMaxLength(40)
                .HasDefaultValueSql("NULL::character varying")
                .HasColumnName("country_name");
            entity.Property(e => e.RegionId).HasColumnName("region_id");

            entity.HasOne(d => d.Region).WithMany(p => p.Countries)
                .HasForeignKey(d => d.RegionId)
                .HasConstraintName("countries_region_id_fkey");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("departments_pkey");

            entity.ToTable("departments");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("department_id");
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(30)
                .HasColumnName("department_name");
            entity.Property(e => e.LocationId).HasColumnName("location_id");
            entity.Property(e => e.ManagerId).HasColumnName("manager_id");

            entity.HasOne(d => d.Location).WithMany(p => p.Departments)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("departments_location_id_fkey");

            entity.HasOne(d => d.Manager).WithMany(p => p.Departments)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("departments_manager_id_fkey");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("employees_pkey");

            entity.ToTable("employees");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("employee_id");
            entity.Property(e => e.CommissionPct)
                .HasPrecision(2, 2)
                .HasDefaultValueSql("NULL::numeric")
                .HasColumnName("commission_pct");
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.Email)
                .HasMaxLength(25)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .HasDefaultValueSql("NULL::character varying")
                .HasColumnName("first_name");
            entity.Property(e => e.HireDate).HasColumnName("hire_date");
            entity.Property(e => e.JobId)
                .HasMaxLength(10)
                .HasColumnName("job_id");
            entity.Property(e => e.LastName)
                .HasMaxLength(25)
                .HasColumnName("last_name");
            entity.Property(e => e.ManagerId).HasColumnName("manager_id");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasDefaultValueSql("NULL::character varying")
                .HasColumnName("phone_number");
            entity.Property(e => e.Salary)
                .HasPrecision(8, 2)
                .HasDefaultValueSql("NULL::numeric")
                .HasColumnName("salary");

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("employees_department_id_fkey");

            entity.HasOne(d => d.Job).WithMany(p => p.Employees)
                .HasForeignKey(d => d.JobId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employees_job_id_fkey");

            entity.HasOne(d => d.Manager).WithMany(p => p.InverseManager)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("employees_manager_id_fkey");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("jobs_pkey");

            entity.ToTable("jobs");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .HasColumnName("job_id");
            entity.Property(e => e.JobTitle)
                .HasMaxLength(35)
                .HasColumnName("job_title");
            entity.Property(e => e.MaxSalary)
                .HasPrecision(6)
                .HasDefaultValueSql("NULL::numeric")
                .HasColumnName("max_salary");
            entity.Property(e => e.MinSalary)
                .HasPrecision(6)
                .HasDefaultValueSql("NULL::numeric")
                .HasColumnName("min_salary");
        });

        modelBuilder.Entity<JobHistory>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.StartDate }).HasName("job_history_pkey");

            entity.ToTable("job_history");

            entity.Property(e => e.Id).HasColumnName("employee_id");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.JobId)
                .HasMaxLength(10)
                .HasColumnName("job_id");

            entity.HasOne(d => d.Department).WithMany(p => p.JobHistories)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("job_history_department_id_fkey");

            entity.HasOne(d => d.Employee).WithMany(p => p.JobHistories)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("job_history_employee_id_fkey");

            entity.HasOne(d => d.Job).WithMany(p => p.JobHistories)
                .HasForeignKey(d => d.JobId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("job_history_job_id_fkey");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("locations_pkey");

            entity.ToTable("locations");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("location_id");
            entity.Property(e => e.City)
                .HasMaxLength(30)
                .HasColumnName("city");
            entity.Property(e => e.CountryId)
                .HasMaxLength(2)
                .HasDefaultValueSql("NULL::bpchar")
                .IsFixedLength()
                .HasColumnName("country_id");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(12)
                .HasDefaultValueSql("NULL::character varying")
                .HasColumnName("postal_code");
            entity.Property(e => e.StateProvince)
                .HasMaxLength(25)
                .HasDefaultValueSql("NULL::character varying")
                .HasColumnName("state_province");
            entity.Property(e => e.StreetAddress)
                .HasMaxLength(40)
                .HasDefaultValueSql("NULL::character varying")
                .HasColumnName("street_address");

            entity.HasOne(d => d.Country).WithMany(p => p.Locations)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("locations_country_id_fkey");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("regions_pkey");

            entity.ToTable("regions");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("region_id");
            entity.Property(e => e.RegionName)
                .HasMaxLength(25)
                .HasDefaultValueSql("NULL::character varying")
                .HasColumnName("region_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
