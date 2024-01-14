using EmployeeManagement.Application.Features.Employee.Queries.GetEmployeeById;

namespace EmployeeManagement.API.EndpointClasses.Employee
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class EmployeeById : ControllerBase
    {
        public ISender _mediator { get; set; }
        public EmployeeById(ISender mediator) => _mediator = mediator;
        
        [HttpGet("/employees/{id}", Name = "GetEmployeeById")]
        [Description("Returns an Employee details based on Id")]
        [SwaggerOperation(Tags = new[] { "Employee" })]
        public async Task<ActionResult> HandleAsync(Guid Id)
        {
            var getEmployeeById = new GetEmployeeByIdQuery() {EmployeeId = Id};
            return getEmployeeById != null ? Ok (await _mediator.Send(getEmployeeById)) : NotFound();
        }
    }
}