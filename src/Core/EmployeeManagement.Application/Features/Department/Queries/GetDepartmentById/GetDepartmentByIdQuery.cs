using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Application.DTOs.Department;

namespace EmployeeManagement.Application.Features.Department.Queries.GetDepartmentById
{
    public class GetDepartmentByIdQuery : IRequest<GetDepartmentByIdQueryResponse<GetDepartmentDTO>>
    {
        public int DepartmentId { get; set; }
    }

    public class GetDepartmentByIdQueryHandler : IRequestHandler<GetDepartmentByIdQuery, GetDepartmentByIdQueryResponse<GetDepartmentDTO>>
    {
        private readonly IDepartmentRepository<GetDepartmentDTO> _departmentRepository;

        public GetDepartmentByIdQueryHandler(IDepartmentRepository<GetDepartmentDTO> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }


        public async Task<GetDepartmentByIdQueryResponse<GetDepartmentDTO>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var response =  await _departmentRepository.GetDepartmentById(request.DepartmentId);
            return new GetDepartmentByIdQueryResponse<GetDepartmentDTO>
            {
                Data = response,
                Message = "Operation successsful",
                Status = true
            };
        }
    }
}