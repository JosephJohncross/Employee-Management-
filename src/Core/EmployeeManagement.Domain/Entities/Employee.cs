namespace EmployeeManagement.Domain.Entities
{
    public class Employee : AuditableEntity
    {
        public Guid Id { get; set; }
        public required Department Department { get; set; }
        public Guid DepartmentId { get; set; }
        
        // public EmployeeDetailsConfig EmployeeDetail { get; set; } = new EmployeeDetailsConfig();
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public List<string> Positions { get; set; } = new ();

        public int GetAge()
        {
            return DateTime.Today.Year - DateOfBirth.Year;
        }

        public string GetFullName ()
        {
            return FirstName + LastName;
        }

    }
}