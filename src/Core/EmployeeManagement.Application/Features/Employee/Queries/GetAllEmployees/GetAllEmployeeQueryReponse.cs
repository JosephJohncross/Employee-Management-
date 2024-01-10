using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Application.Response;

namespace EmployeeManagement.Application.Features.Employee.Queries.GetAllEmployees
{
    public class GetAllEmployeeQueryReponse<T> : BaseResponse
    {
        public GetAllEmployeeQueryReponse() : base() { }

        public T AllEmployees { get; set; }
    }
}