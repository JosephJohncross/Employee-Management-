namespace EmployeeManagement.Application.Features.Department.Queries.GetEmployeeByDepartment
{
    public class GetEmployeeByDepartmentQuery :  IRequest<GetEmployeeByDepartmentResponse<IEnumerable<EmployeeDto>>>
    {
        public int DepartmentId { get; set; }
    }

    public class GetEmployeeByDepartmentQueryHandler : IRequestHandler<GetEmployeeByDepartmentQuery, GetEmployeeByDepartmentResponse<IEnumerable<EmployeeDto>>>
    {
        private readonly IDepartmentRepository<EmployeeDto> _departmentRepository;

        public GetEmployeeByDepartmentQueryHandler(IDepartmentRepository<EmployeeDto> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public async Task<GetEmployeeByDepartmentResponse<IEnumerable<EmployeeDto>>> Handle(GetEmployeeByDepartmentQuery request, CancellationToken cancellationToken)
        {
            var response = await _departmentRepository.GetEmployeeByDepartment(request.DepartmentId);
            return new GetEmployeeByDepartmentResponse<IEnumerable<EmployeeDto>>()
            {
                Data = response,
                Message = "Operation successful",
                Status = true
            };
        }
    }
}