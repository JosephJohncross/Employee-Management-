using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Application.Response;

namespace EmployeeManagement.Application.Features.Employee.Queries.GetAllEmployees
{
    public class GetAllEmployeeQueryReponse : BaseResponse
    {
        public GetAllEmployeeQueryReponse() : base() { }

        public IEnumerable<EmployeeDto> AllEmployees { get; set; }
    }
}