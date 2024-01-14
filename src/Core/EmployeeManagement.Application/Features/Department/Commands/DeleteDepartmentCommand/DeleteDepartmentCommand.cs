using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Application.Response;

namespace EmployeeManagement.Application.Features.Department.Commands.DeleteDepartmentCommand
{
    public class DeleteDepartmentCommand: IRequest<BaseResponse>
    {
        public int DepartmentId { get; set; }
    }

    public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, BaseResponse>
    {
        private readonly IDepartmentRepository<BaseResponse> _departmentRepository;

        public DeleteDepartmentCommandHandler(IDepartmentRepository<BaseResponse> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public async Task<BaseResponse> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            var response = await _departmentRepository.DeleteDepartment(request.DepartmentId);
            return response;
        }
    }
}