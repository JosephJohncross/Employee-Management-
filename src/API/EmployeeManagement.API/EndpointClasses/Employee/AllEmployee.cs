
using EmployeeManagement.Application.Features.Employee.Queries.GetAllEmployees;

namespace EmployeeManagement.API.EndpointClasses.Employee
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class AllEmployee : ControllerBase
    {
        public ISender _mediator { get; set; }
        public AllEmployee(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/api/employees", Name = "AllEmployees")]
        [Description("Returns all employee of the company")]
        [SwaggerOperation(Tags = new[] { "Employee" })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> HandleAsync()
        {
            return Ok(await _mediator.Send(new GetAllEmployeesQuery()));
        }
    }
}