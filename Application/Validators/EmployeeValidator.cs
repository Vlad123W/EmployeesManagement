using EmployeesManagemant.Domain.Entities;
using FluentValidation;

namespace EmployeesManagement.Application.Validators
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Correct employee id is required.");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required.")
                                     .MaximumLength(20).WithMessage("First name must not exceed 20 characters.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required.")
                                    .MaximumLength(25).WithMessage("Last name must not exceed 25 characters.");
            RuleFor(x => x.ManagerId).NotEmpty().WithMessage("Manager id is required.");
            RuleFor(x => x.DepartmentId).GreaterThan(99).WithMessage("Department id is required.");
            RuleFor(x => x.HireDate).NotNull().WithMessage("Hire date is required.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.").MaximumLength(25)
                                 .WithMessage("Email must not exceed 25 characters.");
            RuleFor(x => x.JobId).NotEmpty().WithMessage("Job id is required.")
                                 .MaximumLength(10).WithMessage("Job id must not exceed 10 characters.");
            RuleFor(x => x.CommissionPct).InclusiveBetween(0, 1).WithMessage("Commission percentage must be between 0 and 1.");
            RuleFor(x => x.Salary).GreaterThanOrEqualTo(0).WithMessage("Salary must be a non-negative value.");
            RuleFor(x => x.PhoneNumber).MaximumLength(20).WithMessage("Phone number must not exceed 20 characters.");
        }
    }
}
