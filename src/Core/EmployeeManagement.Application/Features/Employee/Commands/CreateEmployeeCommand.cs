using EmployeeManagement.Application.Response;

namespace EmployeeManagement.Application.Features.Employee.Commands
{
    public class CreateEmployeeCommand : IRequest<BaseResponse>
    {
        public CreateEmployeeDTO EmployeeDTO { get; set; }
    }

    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, BaseResponse>
    {
        private readonly IEmployee<BaseResponse> _response;
        public CreateEmployeeCommandHandler(IEmployee<BaseResponse> response)
        {
            _response = response;
        }
        public async Task<BaseResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var response = await _response.CreateEmployee(request.EmployeeDTO);
            return response;
        }
    }
}