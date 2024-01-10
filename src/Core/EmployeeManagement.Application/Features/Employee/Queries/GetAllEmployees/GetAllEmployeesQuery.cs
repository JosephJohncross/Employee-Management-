
namespace EmployeeManagement.Application.Features.Employee.Queries.GetAllEmployees
{
    public class GetAllEmployeesQuery: IRequest<GetAllEmployeeQueryReponse<IEnumerable<EmployeeDto>>>
    {
        
    }

    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, GetAllEmployeeQueryReponse<IEnumerable<EmployeeDto>>>
    {
        public Task<GetAllEmployeeQueryReponse<IEnumerable<EmployeeDto>>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}