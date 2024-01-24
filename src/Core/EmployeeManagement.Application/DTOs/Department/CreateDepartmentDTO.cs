using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Application.DTOs.Department
{
    /// <summary>
    /// Department with name, abbreviation and parent department id fields
    /// </summary>
    public class CreateDepartmentDTO
    {
        /// <summary>
        /// Name of department
        /// </summary>
        public required string Name { get; set; }
        /// <summary>
        /// Abbreviation of department name
        /// </summary>
        [MaxLength(3)]
        public required string Abbreviation { get; set; }
        /// <summary>
        /// Parent department if any
        /// </summary>
        public Guid? ParentDeparmentId { get; set; }
    }
}