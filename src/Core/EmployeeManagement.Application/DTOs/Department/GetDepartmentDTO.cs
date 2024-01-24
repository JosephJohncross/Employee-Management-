namespace EmployeeManagement.Application.DTOs.Department
{
    /// <summary>
    /// A department with a name, abbreviation and list of sub departments
    /// </summary>
    public class GetDepartmentDTO
    {
        /// <summary>
        /// Name of department
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Abbreviation of department name
        /// </summary>
        public string Abbreviation { get; set; } = string.Empty;
        /// <summary>
        /// List of children department
        /// </summary>
        public List<GetDepartmentDTO> SubDepartment { get; set; } = new List<GetDepartmentDTO>();
    }
}