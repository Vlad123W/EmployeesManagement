using EmployeesManagemant.Data;
using EmployeesManagemant.Domain.Entities;
using EmployeesManagemant.Domain.Interfaces;
using EmployeesManagemant.Infrastructure.Repositories;
using EmployeesManagement.Application.Interfaces;
using EmployeesManagement.Application.Services;
using EmployeesManagement.Application.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();

builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<IValidator<EmployeeDTO>, EmployeeDTOValidator>();

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddScoped<IGenericRepository<Country>, GenericRepository<Country>>();
builder.Services.AddScoped<ICountryService, CountryService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin() 
              .AllowAnyMethod() 
              .AllowAnyHeader(); 
    });
});

var app = builder.Build();

app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();