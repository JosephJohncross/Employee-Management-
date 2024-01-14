using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Application.Response;

namespace EmployeeManagement.Application.Features.Department.Queries.GetAllDepartment
{
    public class GetDepartmentQueryResponse<T> : BaseResponse<T>
    {
        public GetDepartmentQueryResponse() : base()
        {
            
        }
    }
}