namespace EmployeeManagement.Application.DTOs.Department
{
    public class UpdateDepartmentDto
    {
        public Guid DepartmentId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Abbreviation { get; set; } = string.Empty;
        public Guid? ParentDepartmentId { get; set; }
    }
}