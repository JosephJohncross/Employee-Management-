using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Application.Features.Department.Queries.GetEmployeeByDepartment;

namespace EmployeeManagement.API.EndpointClasses.Department
{

    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class EmployeeByDepartment : ControllerBase
    {
        private readonly ISender _mediator;
        public EmployeeByDepartment(ISender mediator) => _mediator = mediator;
        /// <summary>
        /// All Employees per department
        /// </summary>
        /// <param name="deptAbbr">Department abbreviation</param>
        /// <returns>A collection of employees</returns>
        /// 

        [HttpGet("/departments/{departmentId}/employee", Name = "GetEmployeeByDepartment")]
        [Description("Returns all employees in a department")]
        [SwaggerOperation(Tags = new[] { "Department" })]
        public async Task<ActionResult> HandleAsync(int departmentId)
        {
            GetEmployeeByDepartmentQuery getEmployeeByDepartmentId = new() { DepartmentId = departmentId };
            if (getEmployeeByDepartmentId != null)
            {
                return Ok(await _mediator.Send(getEmployeeByDepartmentId));
            }
            else
            {
                return NotFound();
            }
        }
    }
}