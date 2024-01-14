using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.DTOs.Department;
using EmployeeManagement.Application.Repository;
using EmployeeManagement.Application.Response;
using EmployeeManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Infrastructure.Repository
{
    public class DepartmentRepository<T> : IDepartmentRepository<T>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public DepartmentRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException("No service found for Application DB context");
            _mapper = mapper ?? throw new ArgumentNullException("No service found for Automapper");
        }


        public async Task<BaseResponse> CreateDepartment(GetDepartmentDTO departmentDetails)
        {
            var department = _mapper.Map<Department>(departmentDetails);
            var departmentExist = await _context.Department
            .FirstOrDefaultAsync(department => department.Name.ToLower() == departmentDetails.Name.ToLower()
            || department.Abbreviation.ToLower() == departmentDetails.Abbreviation.ToLower());

            if (departmentExist == null)
            {
                await _context.Department.AddAsync(department);
                SaveAsync();
                return new BaseResponse()
                {
                    Message = $"Department {departmentDetails.Name} created ",
                    Status = true
                };
            }
            else
            {
                return new BaseResponse()
                {
                    Message = $"Department creation unsuccessful",
                    Status = false,
                    ValidationErrors = new List<string>()
                    {
                        "Department name or abbreviation already exist"
                    }
                };
            }
        }

        public async Task<BaseResponse> DeleteDepartment(int departmentId)
        {
            var result = await _context.Department.FindAsync(departmentId);

            if (result != null)
            {
                _context.Department.Remove(result);
                SaveAsync();

                return new BaseResponse()
                {
                    Message = "Department deleted successfully",
                    Status = true
                };
            }
            else
            {
                return new BaseResponse()
                {
                    Message = "Department deletion operation unsuccessful",
                    Status = false
                };
            }
        }

        public async Task<IEnumerable<T>> GetAllDepartment()
        {
            var result = await _context.Department.Select(department => department).ToListAsync();
            return _mapper.Map<IEnumerable<T>>(result) ?? new List<T>();
        }

        public async Task<T> GetDepartmentById(int departmentId)
        {
            var result = await _context.Department.FindAsync(departmentId);
            return _mapper.Map<T>(result);
        }

        public async Task<IEnumerable<T>> GetEmployeeByDepartment(int departmenId)
        {
            try
            {
                var department = await _context.Department.FindAsync(departmenId);
                if (department != null) {
                    var employee = await _context.Employee.Where(e => e.Department.Id == departmenId).ToListAsync();
                    return _mapper.Map<IEnumerable<T>>(employee);
                }
                throw new ArgumentNullException("Department does not exist");
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void SaveAsync()
        {
            _context.SaveChangesAsync();
        }

        public async Task<BaseResponse> UpdateDepartment(UpdateDepartmentDto departmentDto)
        {
            try
            {
                var result = await _context.Department.FindAsync(departmentDto.DepartmentId) ?? throw new ArgumentNullException("Department with id was not found");
                if (result != null){
                    _context.Update(result);
                    SaveAsync();

                    return new BaseResponse()
                    {
                        Status = true,
                        Message = "Employee details updated successully"  
                    };
                }
                throw new SqlNullValueException("Department not found");
            }
            catch (Exception e)
            {
                var exceptions = new List<string>();
                foreach (var exception in e.Data.Values)
                {
                    exceptions.Add(exception.ToString() ?? "");
                }
                
                return new BaseResponse() {
                    Status = false,
                    ValidationErrors =  exceptions,
                    Message = "Operation failed"
                };
            }
        }

        async Task<BaseResponse> IDepartmentRepository<T>.DeleteDepartment(int departmentId)
        {
            try
            {
                var result = await _context.Department.FindAsync(departmentId);
                _context.Department.Remove(result);

                return new BaseResponse()
                {
                    Message = "Department deleted successfully",
                    Status = true
                };
            }
            catch (Exception e)
            {
                var exceptions = new List<string>();
                foreach (var exception in e.Data)
                {
                    exceptions.Add(exception.ToString() ?? "");
                }
                return new BaseResponse()
                {
                    Message = "Operation failed",
                    ValidationErrors = exceptions,
                    Status = false
                };
            }
        }
    }
}