namespace EmployeeManagement.Application.DTOs.Department
{
    public class CreateDepartmentDTO
    {
        public required string Name { get; set; }
        public required string Abbreviation { get; set; }
        public Guid? ParentDeparmentId { get; set; }
    }
}