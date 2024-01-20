
using EmployeeManagement.Application.Response;

namespace EmployeeManagement.Application.Features.Employee.Commands
{
    public class DeleteEmployeeCommand : IRequest<BaseResponse>
    {
        public Guid EmployeeId { get; set; }
    }

    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, BaseResponse>
    {
        private readonly IEmployee<BaseResponse> _employee;
        public DeleteEmployeeCommandHandler(IEmployee<BaseResponse> employee) => _employee = employee;
        public async Task<BaseResponse> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var response = await _employee.DeleteEmployee(request.EmployeeId);
            return response;
        }
    }
}