using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Features.Employee.Queries.GetEmployeeById
{
    public class GetEmployeeByIdQuery: IRequest<GetEmployeeByIdResponse<EmployeeDto>>
    {
        public Guid EmployeeId { get; set; }
    }

    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, GetEmployeeByIdResponse<EmployeeDto>>
    {
        public Task<GetEmployeeByIdResponse<EmployeeDto>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}