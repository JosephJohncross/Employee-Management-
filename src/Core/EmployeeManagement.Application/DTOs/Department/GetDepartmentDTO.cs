namespace EmployeeManagement.Application.DTOs.Department
{
    public class GetDepartmentDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Abbreviation { get; set; } = string.Empty;
        public List<GetDepartmentDTO> SubDepartment { get; set; } = new List<GetDepartmentDTO>();
    }
}