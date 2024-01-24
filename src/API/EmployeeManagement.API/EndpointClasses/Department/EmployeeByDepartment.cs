using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Features.Department.Queries.GetEmployeeByDepartment;
using EmployeeManagement.Application.Response;

namespace EmployeeManagement.API.EndpointClasses.Department
{

    [ApiController]
    [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
    public class EmployeeByDepartment : ControllerBase
    {
        private readonly ISender _mediator;
        public EmployeeByDepartment(ISender mediator) => _mediator = mediator;
         
        /// <summary>
        /// Gets all employees in a department
        /// </summary>
        /// <param name="departmentId">The id of the department the employees belong to</param>
        /// <returns></returns>
        [HttpGet("/departments/{departmentId}/employee", Name = "GetEmployeeByDepartment")]
        [Description("Returns all employees in a department")]
        [SwaggerOperation(Tags = new[] { "Department" })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BaseResponse<EmployeeDto[]>>> HandleAsync(Guid departmentId)
        {
            GetEmployeeByDepartmentQuery getEmployeeByDepartmentId = new() { DepartmentId = departmentId };
            return Ok(await _mediator.Send(getEmployeeByDepartmentId));
        }
    }
}