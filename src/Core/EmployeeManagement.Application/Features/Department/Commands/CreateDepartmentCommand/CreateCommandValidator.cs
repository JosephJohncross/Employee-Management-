using EmployeeManagement.Application.DTOs.Department;

namespace EmployeeManagement.Application.Features.Department.Commands.CreateDepartmentCommand
{
    public class CreateCommandValidator : AbstractValidator<CreateDepartmentDTO>
    {
        public CreateCommandValidator()
        {
            RuleFor(model => model.Abbreviation).MaximumLength(4)
            .WithMessage("Maximum allowed length is 4 for Abbrv");
            // RuleFor(model => model.ParentDeparmentId).NotEmpty();
        }
    }
}