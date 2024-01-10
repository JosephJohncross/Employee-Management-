using EmployeeManagement.Application.Response;

namespace EmployeeManagement.Application.Features.Employee.Queries.GetEmployeeByDepartment
{
    public class GetEmployeeByDepartmentResponse : BaseResponse
    {
        public GetEmployeeByDepartmentResponse() : base() { }
        public IEnumerable<EmployeeDto> Employees { get; set; }
    }
}