using EmployeeManagement.Application.Features.Employee.Commands;
using EmployeeManagement.Application.Features.Employee.Queries;
using EmployeeManagement.Application.Repository;
using EmployeeManagement.Application.Response;
using EmployeeManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Infrastructure.Repository
{
    public class EmployeeRepository : IEmployee<EmployeeDto>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public EmployeeRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException("Context not found");
            _mapper = mapper ?? throw new ArgumentNullException("AutoMapper Service not present. Did you forget to inject this service in your configuration file");
        }

        public async Task<IEnumerable<EmployeeDto>> AllEmployee()
        {
            var allEmployee = await _context.Employee.Select(employee => employee).ToListAsync();
            return _mapper.Map<IEnumerable<EmployeeDto>>(allEmployee);
        }

        public Task<BaseResponse<EmployeeDto>> CreateEmployee(CreateEmployeeCommand employeeDetails)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEmployee(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EmployeeDto>> GetEmployeeByDepartmentId()
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeDto> GetEmployeeById()
        {
            throw new NotImplementedException();
        }
    }
}