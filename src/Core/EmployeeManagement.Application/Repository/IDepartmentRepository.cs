using System;
using EmployeeManagement.Application.DTOs.Department;
using EmployeeManagement.Application.Response;
namespace EmployeeManagement.Application.Repository
{
    public interface IDepartmentRepository<T>
    {
        Task<IEnumerable<T>> GetAllDepartment();
        Task<T> GetDepartmentById(int departmentId);
        Task<BaseResponse> CreateDepartment(GetDepartmentDTO departmentDetails); 
        Task<BaseResponse> DeleteDepartment(int departmentId);
        Task<BaseResponse> UpdateDepartment(UpdateDepartmentDto departmentDto);
        Task<IEnumerable<T>> GetEmployeeByDepartment(int departmenId);
        void SaveAsync();
    }
}