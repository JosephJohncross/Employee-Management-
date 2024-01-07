using EmployeeManagement.Application.Features.Department.Commands;
using MediatR;

namespace EmployeeManagement.API.EndpointClasses.Department
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class CreateDepartment: ControllerBase
    {
        private readonly ISender _mediator;
        public CreateDepartment(ISender mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost("/api/department/create", Name = "CreateDepartment")]
        [Description("Creates a department in the organization")]
        [SwaggerOperation(Tags = new[] { "Department"})]
        public async Task<ActionResult> HandleAsync ([FromBody] CreateDepartmentCommand createDepartment)
        {
            var response = await _mediator.Send(createDepartment);
            return Ok(response);
        }
    }
}