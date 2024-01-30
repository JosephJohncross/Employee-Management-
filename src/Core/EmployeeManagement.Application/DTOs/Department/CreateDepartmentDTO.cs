using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Application.DTOs.Department
{
    /// <summary>
    /// Department with name, abbreviation and parent department id fields
    /// </summary>
    /// <param name="Name"> Name of department</param>
    /// <param name="Abbreviation">Abbreviation of department name</param>
    /// <param name="ParentDeparmentId">Parent department if any</param>
    public record CreateDepartmentDTO(
        string Name,
        string Abbreviation,
        Guid? ParentDeparmentId
    );
}