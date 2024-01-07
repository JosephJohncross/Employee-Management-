
namespace EmployeeManagement.Domain.Entities
{
    public class EmployeeDetailsConfig : AuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}