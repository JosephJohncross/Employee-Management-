using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Application.DTOs.Employee
{
    public class UpdateEmployeeDTO
    {
        public Guid EmployeeId { get; set; }
        public Guid DepartmentId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public List<string> Positions { get; set; } = new ();
        // public Address Address { get; set; }
    }
}