using EmployeesManagemant.Data;
using EmployeesManagemant.Domain.Entities;
using EmployeesManagemant.Domain.Interfaces;
using EmployeesManagemant.Infrastructure;
using EmployeesManagemant.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IEmployeeRepository Employees { get; }

        public IGenericRepository<Job> Jobs { get; }

        public IDepartmentRepository Departments { get; }

        public IJobHistoryRepository JobHistory { get; }

        public IGenericRepository<Country> Countries { get; }

        public IGenericRepository<Location> Locations { get; }

        public IGenericRepository<Region> Regions { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Employees = new EmployeeRepository(_context);
            Departments = new DepartmentRepository(_context);
            Jobs = new GenericRepository<Job>(_context);
            JobHistory = new JobHistoryRepository(_context);
            Countries = new GenericRepository<Country>(_context);
            Locations = new GenericRepository<Location>(_context);
            Regions = new GenericRepository<Region>(_context);
        }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}
