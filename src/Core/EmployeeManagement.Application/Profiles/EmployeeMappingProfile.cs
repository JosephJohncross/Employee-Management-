using EmployeeManagement.Application.DTOs.Employee;

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
            .ForMember(dto => dto.Department, opt => opt.Ignore())
            .ForPath(dto => dto.Department.Id, opt => opt.MapFrom(src => src.DepartmentId))
            .ForMember(dto => dto.Positions, opt => opt.MapFrom(src => src.Positions))
            .ReverseMap();

            CreateMap<UpdateEmployeeDTO, Employee>()
            .AfterMap((src, dest) =>
            {
                if (src.FirstName == null) dest.FirstName = dest.FirstName;
                else dest.FirstName = src.FirstName;

                if (src.LastName == null) dest.LastName = dest.LastName;
                else dest.LastName = src.LastName;

                if (src.Email == null) dest.Email = dest.Email;
                else dest.Email = src.Email;

                 if (src.PhoneNumber == null) dest.PhoneNumber = dest.PhoneNumber;
                else dest.PhoneNumber = src.PhoneNumber;

                 if (src.PhoneNumber == null) dest.PhoneNumber = dest.PhoneNumber;
                else dest.PhoneNumber = src.PhoneNumber;

                if (src.DepartmentId == null) dest.DepartmentId = dest.DepartmentId;
                else dest.DepartmentId = src.DepartmentId;

                  if (src.Positions == null) dest.Positions = dest.Positions;
                else dest.Positions = src.Positions;

            })
            // .ForMember(dto => dto.FirstName, opt => opt.MapFrom(src => src.FirstName))
            // .ForMember(dto => dto.LastName, opt => opt.MapFrom(src => src.LastName))
            // .ForMember(dto => dto.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
            // .ForMember(dto => dto.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dto => dto.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
            .ForMember(dto => dto.Department, opt => opt.Ignore())
            .ForPath(dto => dto.Department.Id, opt => opt.MapFrom(src => src.DepartmentId))
            // .ForMember(dto => dto.Positions, opt => opt.Condition((src, dest, srcMember) => srcMember != null))
            // .ForMember(dto => dto.Id, opt => opt.MapFrom(src => src.EmployeeId))
            // .ForMember(dto => dto.Address, opt => opt.MapFrom(src => src.Address))     
            .ReverseMap();
        }
    }
}