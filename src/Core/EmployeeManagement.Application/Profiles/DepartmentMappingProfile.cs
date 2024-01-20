using EmployeeManagement.Application.DTOs.Department;

namespace EmployeeManagement.Application.Profiles
{
    public class DepartmentMappingProfile : Profile
    {
        public DepartmentMappingProfile()
        {
            CreateMap<Guid, Department>()
            .ConstructUsing(guid => new Department {Id = guid});

            CreateMap<Department, GetDepartmentDTO>().ReverseMap();
            CreateMap<Department, CreateDepartmentDTO>()
                .ForMember(dest => dest.ParentDeparmentId, opt => opt.MapFrom(src => src.ParentDepartmentId))
                .ReverseMap();
            CreateMap<Department, UpdateDepartmentDto>().ReverseMap();
        }
    }
}