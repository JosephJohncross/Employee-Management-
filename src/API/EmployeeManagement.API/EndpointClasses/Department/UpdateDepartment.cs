
using Asp.Versioning;
using EmployeeManagement.Application.DTOs.Department;

namespace EmployeeManagement.API.EndpointClasses.Department
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/departments/update")]
    public class UpdateDepartment: ControllerBase
    {
        private readonly ISender _mediator;
        public UpdateDepartment(ISender mediator) => _mediator = mediator;

        /// <summary>
        /// Updates a department details
        /// </summary>
        /// <param name="departmentDTO">Details to update in the department</param>
        /// <returns></returns>

        [HttpPatch(Name = "UpdateDepartment")]
        [Description("Updates details of a department in the organization")]
        [SwaggerOperation(Tags = new[] { "Department"})]
        [MapToApiVersion(1)]
        public async Task<ActionResult> HandleAsync ([FromBody] UpdateDepartmentDto departmentDTO)
        {
            var response = await _mediator.Send(departmentDTO);
            return Ok(response);
        }
    }
}