namespace EmployeeManagement.Domain.Entities
{
    public class Employee : AuditableEntity
    {
        public Guid Id { get; set; }
        public required Department Department { get; set; }
        public EmployeeDetailsConfig EmployeeDetail { get; set; } = new EmployeeDetailsConfig();
    }
}