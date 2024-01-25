
using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Features.Employee.Commands;

namespace EmployeeManagement.API.EndpointClasses.Employee
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    // [ApiExplorerSettings(GroupName = "EmployeeManagementEmployee")]
    public class CreateEmployee : ControllerBase
    {
        private readonly ISender _mediator;
        public CreateEmployee(ISender mediator) => _mediator = mediator;

        [HttpPost("/employees/create", Name = "CreateEmployee")]
        [Description("Creates a new employee")]
        [SwaggerOperation(Tags = new[] { "Employee" })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> HandleAsync([FromBody] CreateEmployeeDTO createEmployee)
        {
            var employeeDetails = new CreateEmployeeCommand(){EmployeeDTO = createEmployee};
            var response = await _mediator.Send(employeeDetails);
            return Ok(response);
        }
    }
}