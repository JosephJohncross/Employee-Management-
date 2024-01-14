using EmployeeManagement.Application.DTOs.Department;
using EmployeeManagement.Application.Response;

namespace EmployeeManagement.Application.Features.Department.Commands.CreateDepartmentCommand
{
    public class CreateDepartmentCommand : IRequest<BaseResponse>
    {
        public GetDepartmentDTO DepartmentDTO { get; set; }
    }

    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, BaseResponse>
    {
        private readonly IDepartmentRepository<GetDepartmentDTO> _departmentRepository;

        public CreateDepartmentCommandHandler(IDepartmentRepository<GetDepartmentDTO > departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public async Task<BaseResponse> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var response = await _departmentRepository.CreateDepartment(request.DepartmentDTO);
            return response;
        }
    }
}