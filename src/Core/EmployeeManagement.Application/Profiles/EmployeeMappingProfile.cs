
using EmployeeManagement.Application.DTOs.Department;
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
            .ForMember(dto => dto.Positions, opt => opt.MapFrom(src => src.Positions))
            .ReverseMap();


            CreateMap<CreateEmployeeDTO, Employee>()
            .ForMember(dto => dto.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dto => dto.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dto => dto.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
            .ForMember(dto => dto.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dto => dto.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
            .ForMember(dto => dto.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
            .ForMember(dto => dto.Department, opt => opt.Ignore())
            .ForPath(dto => dto.Department.Id, opt => opt.MapFrom(src => src.DepartmentId))
            .ForMember(dto => dto.Positions, opt => opt.MapFrom(src => src.Positions))
            .ReverseMap();

            CreateMap<int, Department>()
            .ConstructUsing(guid => new Department {Id = guid});

            CreateMap<Department, GetDepartmentDTO>().ReverseMap();
        }
    }
}