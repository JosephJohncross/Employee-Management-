using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Application.Response;

namespace EmployeeManagement.Application.Features.Department.Queries.GetDepartmentById
{
    public class GetDepartmentByIdQueryResponse<T> : BaseResponse<T>
    {
        public GetDepartmentByIdQueryResponse() : base()
        {
            
        }
    }
}