using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Application.DTOs.Employee;
using EmployeeManagement.Application.Response;

namespace EmployeeManagement.Application.Features.Employee.Commands.UpdateEmployeeCommand
{
    public class UpdateEmployeeCommand : IRequest<BaseResponse>
    {
        public UpdateEmployeeDTO employeeDTO { get; set; }
    }

    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, BaseResponse>
    {
        private readonly IEmployee<BaseResponse> _employeeRespository;
        public UpdateEmployeeCommandHandler(IEmployee<BaseResponse> employeeRespository) => _employeeRespository = employeeRespository;
        public async Task<BaseResponse> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var response = await _employeeRespository.UpdateEmployee(request.employeeDTO);
            return response;
        }
    }
}