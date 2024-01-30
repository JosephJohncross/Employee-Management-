namespace EmployeeManagement.Application.DTOs
{
    // public class EmployeeDto
    // {
    //     public string GetFullName { get; set; } = string.Empty;
    //     public DateOnly DateOfBirth { get; set; }
    //     public string Email { get; set; }
    //     public string PhoneNumber { get; set; }
    //     public List<string> Positions { get; set; } = new ();
    //     public string DepartmentName { get; set; }
    // }

    /// <summary>
    /// DTO for employee personal details
    /// </summary>
    /// <param name="GetFullName">Employee fullname (Firstname + LastName)</param>
    /// <param name="DateOfBirth">Employee Date of birth</param>
    /// <param name="Email">Employee email address</param>
    /// <param name="PhoneNumber">Employee phone number</param>
    /// <param name="Positions">Employee positions in the department or organisation </param>
    /// <param name="DepartmentName">Department name employee belong to</param>
    public record EmployeeDto(
        string GetFullName,
        DateOnly DateOfBirth,
        string Email,
        string PhoneNumber,
        List<string> Positions,
        string DepartmentName
    );
}