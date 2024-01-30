namespace EmployeeManagement.Application.DTOs.Department
{

    /// <summary>
    /// A department with a name, abbreviation and list of sub departments
    /// </summary>
    /// <param name="Name">Name of department</param>
    /// <param name="Abbreviation">Abbreviation of department name</param>
    /// <param name="SubDepartment">List of children department</param>
    public record GetDepartmentDTO(
        string Name,
        string Abbreviation,
        List<GetDepartmentDTO> SubDepartment
    );
}