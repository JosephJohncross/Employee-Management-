using EmployeeManagement.Application.Repository;

namespace EmployeeManagement.Application.Features.Employee.Queries.GetEmployeeById
{
    public class GetEmployeeByIdQuery: IRequest<GetEmployeeByIdResponse<EmployeeDto>>
    {
        public Guid EmployeeId { get; set; }
    }

    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, GetEmployeeByIdResponse<EmployeeDto>>
    {
        private readonly IEmployee<EmployeeDto> _employee;
        public GetEmployeeByIdQueryHandler(IEmployee<EmployeeDto> employee)
        {
            _employee = employee;
        }

        public async Task<GetEmployeeByIdResponse<EmployeeDto>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _employee.GetEmployeeById(request.EmployeeId);
            var response = new GetEmployeeByIdResponse<EmployeeDto>() {
                Data = result,
                Message = "Operation successful",
                Status = true
            };

            return response;
        }
    }
}