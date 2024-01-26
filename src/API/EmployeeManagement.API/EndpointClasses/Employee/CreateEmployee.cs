
using Asp.Versioning;
using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Features.Employee.Commands;

namespace EmployeeManagement.API.EndpointClasses.Employee
{
    [ApiController]
    [ApiVersion("1.0")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Route("api/v{v:apiVersion}/employees/create")]
    // [ApiExplorerSettings(GroupName = "EmployeeManagementEmployee")]
    public class CreateEmployee : ControllerBase
    {
        private readonly ISender _mediator;
        public CreateEmployee(ISender mediator) => _mediator = mediator;

        /// <summary>
        /// Creates a new employee in the organisation
        /// </summary>
        /// <param name="createEmployee">New employee details</param>
        /// <returns></returns>
        [HttpPost(Name = "CreateEmployee")]
        [Description("Creates a new employee")]
        [SwaggerOperation(Tags = new[] { "Employee" })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> HandleAsync([FromBody] CreateEmployeeDTO createEmployee)
        {
            var employeeDetails = new CreateEmployeeCommand(){EmployeeDTO = createEmployee};
            var response = await _mediator.Send(employeeDetails);
            return Ok(response);
        }
    }
}