
using EmployeeManagement.Application.Features.Employee.Queries;

namespace EmployeeManagement.Application.Profiles
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<Employee, EmployeeDto>()
            .ForMember(dto => dto.GetFullName, opt => opt.MapFrom(src => src.GetFullName()))
            .ForMember(dto => dto.DepartmentName, opt => opt.MapFrom(src => src.Department.Name))
            .ForMember(dto => dto.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
            .ForMember(dto => dto.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dto => dto.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
            .ForMember(dto => dto.Positions, opt => opt.MapFrom(src => src.Positions));
        }
    }
}