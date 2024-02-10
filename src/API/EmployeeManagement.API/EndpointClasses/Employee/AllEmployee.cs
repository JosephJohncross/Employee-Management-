
using Asp.Versioning;
using EmployeeManagement.Application.Features.Employee.Queries.GetAllEmployees;
using EmployeeManagement.Application.Response;

namespace EmployeeManagement.API.EndpointClasses.Employee
{
    // Works for now
    [ApiController]
    [ApiVersion("1.0")]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("api/v{v:apiVersion}/employees")]
    
    public class AllEmployee : ControllerBase
    {
        public ISender _mediator { get; set; }
        public AllEmployee(ISender mediator) => _mediator = mediator;

        /// <summary>
        /// Gets all employee in the organization
        /// </summary>
        /// <returns></returns>
        [HttpGet( Name = "AllEmployees")]
        [Description("Returns all employee of the company")]
        [SwaggerOperation(Tags = new[] { "Employee" })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult<BaseResponse>> HandleAsync([FromQuery] string? searchTerm)
        {
            return Ok(await _mediator.Send(new GetAllEmployeesQuery(searchTerm)));
        }
    }
}