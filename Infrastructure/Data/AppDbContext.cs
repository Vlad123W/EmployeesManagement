using EmployeesManagemant.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace EmployeesManagemant.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<Job> Jobs => Set<Job>();
        public DbSet<JobHistory> JobHistories => Set<JobHistory>();
        public DbSet<Location> Locations => Set<Location>();
        public DbSet<Country> Countries => Set<Country>();
        public DbSet<Region> Regions => Set<Region>();
        public DbSet<Vacation> Vacations => Set<Vacation>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

        }
    }
}
