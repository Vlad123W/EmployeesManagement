using EmployeesManagemant.Domain.Entities;
using FluentValidation;

namespace EmployeesManagement.Application.Validators
{
    public class EmployeeDTOValidator : AbstractValidator<EmployeeDTO>
    {
        public EmployeeDTOValidator() 
        {
            RuleFor(x => x.EmployeeId).GreaterThan(0).WithMessage("Correct employee id is required.");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required.")
                                     .MaximumLength(20).WithMessage("First name must not exceed 20 characters.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required.")
                    .MaximumLength(25).WithMessage("Last name must not exceed 25 characters.");
            RuleFor(x => x.ManagerId).NotEmpty().WithMessage("Manager id is required.");
            RuleFor(x => x.DepartmentId).GreaterThan(99).WithMessage("Department id is required.");
            RuleFor(x => x.HireDate).NotNull().WithMessage("Hire date is required.");
        }

    }
}
