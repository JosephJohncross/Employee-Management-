
using EmployeeManagement.Application.Features.Employee.Commands;

namespace EmployeeManagement.API.EndpointClasses.Employee
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class CreateEmployee : ControllerBase
    {
        private readonly ISender _mediator;
        public CreateEmployee(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("/api/employees/create", Name = "CreateEmployee")]
        [Description("Creates a new employee")]
        [SwaggerOperation(Tags = new[] { "Employee" })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> HandleAsync([FromBody] CreateEmployeeCommand createEmployee)
        {
            var response = await _mediator.Send(createEmployee);
            return Ok(response);
        }
    }
}