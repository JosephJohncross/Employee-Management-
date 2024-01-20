using EmployeeManagement.Application.DTOs.Employee;
using EmployeeManagement.Application.Response;

namespace EmployeeManagement.Application.Contracts.Infrastructure
{
    public interface IEmployee<T>
    {
        public Task<IEnumerable<T>> AllEmployee();
        public Task<T> GetEmployeeById(Guid id);
        public Task<BaseResponse> CreateEmployee(CreateEmployeeDTO employeeDetails);
        public Task<BaseResponse> DeleteEmployee(Guid employeeId);
        Task<BaseResponse> UpdateEmployee(UpdateEmployeeDTO employeeDTO);
        Task<int> SaveAsync();
    }
}