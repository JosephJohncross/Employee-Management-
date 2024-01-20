using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Domain.Entities
{
    public class Employee : AuditableEntity
    {
        [Key]
        public Guid Id { get; set; }
        public required Department Department { get; set; }
        public Guid DepartmentId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }

        [EmailAddress]
        
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public List<string> Positions { get; set; } = new ();
        public Address? Address { get; set; }
        public int? GetAge()
        {
            return DateTime.Today.Year - DateOfBirth.Year;
        }

        public string GetFullName ()
        {
            return FirstName + " " + LastName;
        }

    }
}