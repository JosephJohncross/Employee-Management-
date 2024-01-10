using EmployeeManagement.Application.Features.Employee.Queries.GetEmployeeByDepartment;

namespace EmployeeManagement.API.EndpointClasses.Employee
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class EmployeeByDepartment : ControllerBase
    {

        private readonly ISender _mediator;
        public EmployeeByDepartment(ISender mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// All Employees per department
        /// </summary>
        /// <param name="deptAbbr">Department abbreviation</param>
        /// <returns>A collection of employees</returns>
        /// 

        [HttpGet("/api/employees/{departmentId}", Name = "GetEmployeeByDepartment")]
        [Description("Returns all employees in a department")]
        [SwaggerOperation(Tags = new[] { "Employee" })]
        public async Task<ActionResult> HandleAsync(Guid departmentId)
        {
            GetEmployeeByDepartmentQuery getEmployeeByDepartmentId =  new () {DepartmentId= departmentId};
            if (getEmployeeByDepartmentId != null) {
                return Ok(await _mediator.Send(getEmployeeByDepartmentId));
            }else{
                return NotFound();
            }
        }
    }
}