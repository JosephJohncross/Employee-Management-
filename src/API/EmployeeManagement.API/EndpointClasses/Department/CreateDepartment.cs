using EmployeeManagement.Application.DTOs.Department;
using EmployeeManagement.Application.Features.Department.Commands.CreateDepartmentCommand;

namespace EmployeeManagement.API.EndpointClasses.Department
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class CreateDepartment: ControllerBase
    {
        private readonly ISender _mediator;
        public CreateDepartment(ISender mediator) => _mediator = mediator;
        
        [HttpPost("/departments/create", Name = "CreateDepartment")]
        [Description("Creates a department in the organization")]
        [SwaggerOperation(Tags = new[] { "Department"})]
        public async Task<ActionResult> HandleAsync ([FromBody] GetDepartmentDTO departmentDTO)
        {
            var response = await _mediator.Send(new CreateDepartmentCommand(){DepartmentDTO = departmentDTO});
            return Ok(response);
        }
    }
}