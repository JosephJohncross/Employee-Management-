using EmployeeManagement.Application.Response;

namespace EmployeeManagement.Application.Features.Employee.Commands
{
    public class CreateEmployeeCommand :  IRequest<BaseResponse>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public Guid DepartmentId { get; set; }
        
        public List<string> Positions { get; set; } = new ();
    }

    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, BaseResponse>
    {
        public Task<BaseResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}