using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Application.DTOs.Department;

namespace EmployeeManagement.Application.Features.Department.Queries.GetAllDepartment
{
    public class GetAllDepartmentQuery : IRequest<GetDepartmentQueryResponse<IEnumerable<GetDepartmentDTO>>>
    {
        
    }

    public class GetAllDepartmentQueryHandler : IRequestHandler<GetAllDepartmentQuery, GetDepartmentQueryResponse<IEnumerable<GetDepartmentDTO>>>
    {
         private readonly IDepartmentRepository<GetDepartmentDTO> _departmentRepository;

        public GetAllDepartmentQueryHandler(IDepartmentRepository<GetDepartmentDTO> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<GetDepartmentQueryResponse<IEnumerable<GetDepartmentDTO>>> Handle(GetAllDepartmentQuery request, CancellationToken cancellationToken)
        {
            var response = await _departmentRepository.GetAllDepartment();
            return new GetDepartmentQueryResponse<IEnumerable<GetDepartmentDTO>>
            {
                Data = response,
                Message = "Operation successful",
                Status = true
            };
        }
    }
}