using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Application.Features.Employee.Queries;

namespace EmployeeManagement.Application.Repository
{
    public interface IEmployee<T>
    {
        public Task<IEnumerable<T>> AllEmployee();
        public Task<IEnumerable<T>> GetEmployeeByDepartmentId();
        public Task<T> GetEmployeeById();
    }
}