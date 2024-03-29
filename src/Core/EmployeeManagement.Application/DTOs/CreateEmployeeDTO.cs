using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.DTOs
{
    // public class CreateEmployeeDTO
    // {
    //     public string FirstName { get; set; } = string.Empty;
    //     public string LastName { get; set; } = string.Empty;
    //     public DateOnly DateOfBirth { get; set; }
    //     public string Email { get; set; }
    //     public string PhoneNumber { get; set; }
    //     public Guid DepartmentId { get; set; }
        
    //     public List<string> Positions { get; set; } = new ();
    // }
    public record CreateEmployeeDTO(
        string FirstName,
        string LastName,
        DateOnly DateOfBirth,
        string Email,
        string PhoneNumber,
        Guid DepartmentId,
        List<string> Positions
    );
}