using EmployeeManagement.Application.DTOs.Department;
using EmployeeManagement.Application.Response;

namespace EmployeeManagement.Application.Contracts.Infrastructure
{
    public interface IDepartmentRepository<T>
    {Task<IEnumerable<T>> GetAllDepartment();
        Task<T> GetDepartmentById(Guid departmentId);
        Task<BaseResponse> CreateDepartment(CreateDepartmentDTO departmentDetails); 
        Task<BaseResponse> DeleteDepartment(Guid departmentId);
        Task<BaseResponse> UpdateDepartment(UpdateDepartmentDto departmentDto);
        Task<IEnumerable<T>> GetEmployeeByDepartment(Guid departmenId);
        void SaveAsync();
        
    }
}