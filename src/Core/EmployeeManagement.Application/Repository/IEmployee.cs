using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Application.Features.Employee.Commands;
using EmployeeManagement.Application.Features.Employee.Queries;
using EmployeeManagement.Application.Response;

namespace EmployeeManagement.Application.Repository
{
    public interface IEmployee<T>
    {
        public Task<IEnumerable<T>> AllEmployee();
        // public Task<IEnumerable<T>> GetEmployeeByDepartmentId();
        public Task<T> GetEmployeeById(Guid id);
        public Task<BaseResponse> CreateEmployee(CreateEmployeeDTO employeeDetails);
        public Task DeleteEmployee(Guid employeeId);
        void SaveAsync();
    }
}