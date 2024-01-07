using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Features.Employee.Queries
{
    public class EmployeeDto
    {
        public string GetFullName { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<string> Positions { get; set; } = new ();
        public string DepartmentName { get; set; }
    }
}