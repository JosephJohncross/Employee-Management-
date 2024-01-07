using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Domain.Common
{
    public class AuditableEntity
    {

        public AuditableEntity()
        {   
            CreatedAt = DateTime.UtcNow;
            ModifiedAt = CreatedAt;
        }

        public DateTime CreatedAt { get; }
        public string? CreatedBy { get; set; }
        public DateTime ModifiedAt { get; }
        public string? ModifiedBy { get; set; }
    }
}