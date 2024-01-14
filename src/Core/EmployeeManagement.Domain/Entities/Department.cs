using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Domain.Entities
{
    public class Department : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Abbreviation { get; set; } = string.Empty;

        // Projects and initiatives --- NOte project can be shared by various departments
        
        // Budget and resources
    }
}