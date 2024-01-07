
namespace EmployeeManagement.Application.Features.Employee.Commands
{
    public class DeleteEmployeeCommand : IRequest
    {
        public Guid EmployeeId { get; set; }
    }

    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
    {
        public Task Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}