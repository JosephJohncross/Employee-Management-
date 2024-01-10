using EmployeeManagement.Application.Response;

namespace EmployeeManagement.Application.Features.Employee.Queries.GetEmployeeById
{
    public class GetEmployeeByIdResponse<T>: BaseResponse
    {
        public GetEmployeeByIdResponse() : base()
        {
            
        }

        public T Employee { get; set; }
    }
}