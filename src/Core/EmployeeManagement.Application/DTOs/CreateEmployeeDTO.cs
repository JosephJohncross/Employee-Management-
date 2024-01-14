using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.DTOs
{
    public class CreateEmployeeDTO
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public int DepartmentId { get; set; }
        
        public List<string> Positions { get; set; } = new ();
    }
}