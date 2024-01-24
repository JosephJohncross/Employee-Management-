
using System.Data.SqlTypes;
using EmployeeManagement.Application.Contracts.Infrastructure;
using EmployeeManagement.Application.DTOs.Department;
using EmployeeManagement.Application.Response;
using EmployeeManagement.Infrastructure.Data;
using EmployeeManagement.Infrastructure.Middelwares.GlobalExceptionHandlingMiddleware;
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


        public async Task<BaseResponse> CreateDepartment(CreateDepartmentDTO departmentDetails)
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
                throw new EmployeeManagementBadRequestException("Department already exist");
            }
        }

        public async Task<BaseResponse> DeleteDepartment(Guid departmentId)
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
                throw new EmployeeManagementNotFoundException("Department does not exist");
            }
        }

        public async Task<IEnumerable<T>> GetAllDepartment()
        {
            var result = await _context.Department.Select(department => department).ToListAsync();
            return _mapper.Map<IEnumerable<T>>(result) ?? new List<T>();
        }

        public async Task<T> GetDepartmentById(Guid departmentId)
        {
            var department = await _context.Department.FindAsync(departmentId) ?? throw new EmployeeManagementNotFoundException("Department does not exist");
            return _mapper.Map<T>(department);

        }

        public async Task<IEnumerable<T>> GetEmployeeByDepartment(Guid departmenId)
        {

            var department = await _context.Department.FindAsync(departmenId);
            if (department != null)
            {
                var employee = await _context.Employee.Where(e => e.Department.Id == departmenId).ToListAsync();
                return _mapper.Map<IEnumerable<T>>(employee);
            }

            throw new EmployeeManagementNotFoundException("Department does not exist");

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
                if (result != null)
                {
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

                return new BaseResponse()
                {
                    Status = false,
                    ValidationErrors = exceptions,
                    Message = "Operation failed"
                };
            }
        }

    }
}