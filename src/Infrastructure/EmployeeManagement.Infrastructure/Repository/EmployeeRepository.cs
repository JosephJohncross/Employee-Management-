using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Repository;
using EmployeeManagement.Application.Response;
using EmployeeManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Infrastructure.Repository
{
    public class EmployeeRepository<T> : IEmployee<T>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public EmployeeRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException("Context not found");
            _mapper = mapper ?? throw new ArgumentNullException("AutoMapper Service not present. Did you forget to inject this service in your configuration file");
        }

        public async Task<BaseResponse> CreateEmployee(CreateEmployeeDTO employeeDetails)
        {
            var employee = _mapper.Map<Employee>(employeeDetails);
            var department = await _context.Department.FindAsync(employeeDetails.DepartmentId);
            
        
            if (department != null){
                await _context.Employee.AddAsync(employee);
                SaveAsync();
                
                return new BaseResponse() {
                    Message = "Employee created sucessfully",
                    Status = true
                };
            }else {
                return new BaseResponse() {
                    Message = "Department does not exist",
                    Status = false
                };
            }
           
        }

        public Task DeleteEmployee(Guid employeeId)
        {
            throw new NotImplementedException();
        }
        
        public void SaveAsync()
        {
            _context.SaveChangesAsync();
        }

        async Task<IEnumerable<T>> IEmployee<T>.AllEmployee()
        {
            var allEmployee = await _context.Employee.Select(employee => employee).ToListAsync();
            return _mapper.Map<IEnumerable<T>>(allEmployee);
        }

        async Task<T> IEmployee<T>.GetEmployeeById(Guid id)
        {
             var result =  await _context.Employee.FindAsync(id);
            return _mapper.Map<T>(result);
        }
    }
}