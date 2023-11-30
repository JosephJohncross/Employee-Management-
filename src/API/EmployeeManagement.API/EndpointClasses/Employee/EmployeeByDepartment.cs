namespace EmployeeManagement.API.EndpointClasses.Employee
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class EmployeeByDepartment : ControllerBase
    {
        /// <summary>
        /// All Employees per department
        /// </summary>
        /// <param name="departmentInitial">Department abbreviation</param>
        /// <returns>A collection of employees</returns>
        /// 
        [HttpGet("/api/employees/{deptAbbr}", Name = "GetEmployeeByDepartment")]
        [Description("Returns all employees in a department")]
        [SwaggerOperation(Tags = new[] { "Employee" })]
        public ActionResult HandleAsync(string departmentInitial)
        {
            return Ok();
        }
    }
}