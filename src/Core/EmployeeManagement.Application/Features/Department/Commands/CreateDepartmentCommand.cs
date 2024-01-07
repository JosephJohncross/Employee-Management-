namespace EmployeeManagement.Application.Features.Department.Commands
{
    public class CreateDepartmentCommand : IRequest<CreateDepartmentCommandResponse>
    {
        public string Name { get; set; } = string.Empty;
        public string Abbreviation { get; set; } = string.Empty;
    }

    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, CreateDepartmentCommandResponse>
    {
        public Task<CreateDepartmentCommandResponse> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}