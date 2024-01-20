using EmployeeManagement.Application.Contracts.Infrastructure;
using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.DTOs.Employee;
using EmployeeManagement.Application.Response;
using EmployeeManagement.Infrastructure.Data;
using EmployeeManagement.Infrastructure.Middelwares.GlobalExceptionHandlingMiddleware;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Infrastructure.Repository
{
    public class EmployeeRepository<T> : IEmployee<T>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public EmployeeRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context ?? throw new EmployeeManagementServiceNotFound("Context not found");
            _mapper = mapper ?? throw new EmployeeManagementServiceNotFound("AutoMapper Service not present. Did you forget to inject this service in your configuration file");
        }

        public async Task<BaseResponse> CreateEmployee(CreateEmployeeDTO employeeDetails)
        {
            try
            {
                var department = _context.Department.Find(employeeDetails.DepartmentId);

                if (department != null)
                {
                    // No need to explicitly detach, as Find typically retrieves without tracking
                    var employee = _mapper.Map<Employee>(employeeDetails);
                    employee.Department = department;

                    await _context.Employee.AddAsync(employee);
                    await SaveAsync();

                    return new BaseResponse
                    {
                        Message = "Employee created successfully",
                        Status = true
                    };
                }
                else
                {
                    throw new EmployeeManagementNotFoundException("Department does not exist");
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                return new BaseResponse
                {
                    Message = $"Error creating employee: {ex.Message}",
                    Status = false
                };
            }
        }

        public async Task<BaseResponse> DeleteEmployee(Guid employeeId)
        {
            var employee = _context.Employee.Find(employeeId);
            if (employee != null)
            {
                _context.Employee.Remove(employee);
                await SaveAsync();
                return new BaseResponse
                {
                    Message = "Employee successfuly deleted",
                    Status = true
                };
            }
            else
            {
                throw new EmployeeManagementNotFoundException("Employee does not exist");
            }
        }

        public async Task<int> SaveAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result;
        }

        public async Task<BaseResponse> UpdateEmployee(UpdateEmployeeDTO employeeDTO)
        {
            var mappedEmployee = _mapper.Map<Employee>(employeeDTO);
            var employee = await _context.Employee.FirstOrDefaultAsync(e => e.Id == employeeDTO.EmployeeId);

            if (employee == null)
            {
                return new BaseResponse
                {
                    Message = "Employee with id does not exist",
                    Status = false
                };
            }
            try
            {
                var result = _context.Employee.Update(employee);
                await SaveAsync();

                return new BaseResponse
                {
                    Status = true,
                    Message = "Employee successfully updated",
                };
            }
            catch (Exception e)
            {
                var result = _context.Employee.Update(employee);
                return new BaseResponse
                {
                    Status = false,
                    Message = "Operation unsuccessful",
                };
            }
        }

        async Task<IEnumerable<T>> IEmployee<T>.AllEmployee()
        {
            var allEmployee = await _context.Employee.Include(employee => employee.Department).ToListAsync();
            return _mapper.Map<IEnumerable<T>>(allEmployee);
        }

        async Task<T> IEmployee<T>.GetEmployeeById(Guid id)
        {
            var result = await _context.Employee.Include(d => d.Department).FirstOrDefaultAsync(e => e.Id == id) ?? throw new EmployeeManagementNotFoundException("Employee does not exist");
            return _mapper.Map<T>(result);
        }
    }
}