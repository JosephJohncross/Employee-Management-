using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.DTOs.Department
{
    public class UpdateDepartmentDto
    {
        public int DepartmentId { get; set; }
         public string Name { get; set; } = string.Empty;
        public string Abbreviation { get; set; } = string.Empty;
    }
}