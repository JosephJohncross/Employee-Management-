
using EmployeeManagement.Application.DTOs.Department;

namespace EmployeeManagement.API.EndpointClasses.Department
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class UpdateDepartment: ControllerBase
    {
        private readonly ISender _mediator;
        public UpdateDepartment(ISender mediator) => _mediator = mediator;
        
        [HttpPatch("/departments/update", Name = "UpdateDepartment")]
        [Description("Updates details of a department in the organization")]
        [SwaggerOperation(Tags = new[] { "Department"})]
        public async Task<ActionResult> HandleAsync ([FromBody] UpdateDepartmentDto departmentDTO)
        {
            var response = await _mediator.Send(departmentDTO);
            return Ok(response);
        }
    }
}