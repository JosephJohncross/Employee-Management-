

namespace EmployeeManagement.Application.Features.Employee.Queries.GetEmployeeByDepartment
{
    public class GetEmployeeByDepartmentQuery :  IRequest<GetEmployeeByDepartmentResponse>
    {
        public Guid DepartmentId { get; set; }
    }

    public class GetEmployeeByDepartmentQueryHandler : IRequestHandler<GetEmployeeByDepartmentQuery, GetEmployeeByDepartmentResponse>
    {
        public Task<GetEmployeeByDepartmentResponse> Handle(GetEmployeeByDepartmentQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}