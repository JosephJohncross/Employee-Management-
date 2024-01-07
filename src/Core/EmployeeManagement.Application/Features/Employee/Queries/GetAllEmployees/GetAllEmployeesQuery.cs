
namespace EmployeeManagement.Application.Features.Employee.Queries.GetAllEmployees
{
    public class GetAllEmployeesQuery: IRequest<GetAllEmployeeQueryReponse>
    {
        
    }

    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, GetAllEmployeeQueryReponse>
    {
        public Task<GetAllEmployeeQueryReponse> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}