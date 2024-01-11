
using EmployeeManagement.Application.Repository;

namespace EmployeeManagement.Application.Features.Employee.Queries.GetAllEmployees
{
    public class GetAllEmployeesQuery: IRequest<GetAllEmployeeQueryReponse<IEnumerable<EmployeeDto>>>
    {
        
    }

    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, GetAllEmployeeQueryReponse<IEnumerable<EmployeeDto>>>
    {
        private readonly IEmployee<EmployeeDto> _employeeService;
        public GetAllEmployeesQueryHandler(IEmployee<EmployeeDto> employeeService)
        {
            _employeeService = employeeService;
        }
        
        public async Task<GetAllEmployeeQueryReponse<IEnumerable<EmployeeDto>>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var result =  await _employeeService.AllEmployee();
            var response = new GetAllEmployeeQueryReponse<IEnumerable<EmployeeDto>>() {
                Data = result,
                Message = "Operation successful",
                Status = true
            };

            return response;
        }
    }
}