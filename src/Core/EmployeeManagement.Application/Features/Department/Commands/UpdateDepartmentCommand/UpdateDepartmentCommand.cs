using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Application.DTOs.Department;
using EmployeeManagement.Application.Response;

namespace EmployeeManagement.Application.Features.Department.Commands.UpdateDepartmentCommand
{
    public class UpdateDepartmentCommand : IRequest<BaseResponse>
    {
        public UpdateDepartmentDto departmentDetails { get; set; }
    }

    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, BaseResponse>
    {
        private readonly IDepartmentRepository<BaseResponse> _departmentRepository;
        public UpdateDepartmentCommandHandler(IDepartmentRepository<BaseResponse> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public async Task<BaseResponse> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var response = await _departmentRepository.UpdateDepartment(request.departmentDetails);
            return response;
        }
    }
}