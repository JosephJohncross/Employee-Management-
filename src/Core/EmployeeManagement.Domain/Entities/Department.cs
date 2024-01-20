using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Domain.Entities
{
    public class Department : AuditableEntity
    {
        [Key]
        public Guid Id { get; set; }
        public  string Name { get; set; }
        public string Abbreviation { get; set; }
        public List<Department> SubDepartments { get; set; } = new List<Department>();
        public Department? ParentDepartment { get; set; }
        public Guid? ParentDepartmentId { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();

        // Projects and initiatives --- Note project can be shared by various departments
        
        // Budget and resources
    }
}