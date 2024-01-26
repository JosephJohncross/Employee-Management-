using Asp.Versioning;
using EmployeeManagement.Application.DTOs.Department;
using EmployeeManagement.Application.Features.Department.Commands.CreateDepartmentCommand;
using EmployeeManagement.Application.Response;

namespace EmployeeManagement.API.EndpointClasses.Department
{
    [ApiController]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/departments/create")]
    public class CreateDepartment: ControllerBase
    {
        private readonly ISender _mediator;
        public CreateDepartment(ISender mediator) => _mediator = mediator;
        
        /// <summary>
        /// Creates a new department in an organization
        /// </summary>
        /// <param name="departmentDTO">Details of a new department</param>
        /// <returns></returns>
    
        [HttpPost(Name = "CreateDepartment")]
        [Description("Creates a department in the organization")]
        [SwaggerOperation(Tags = new[] { "Department"})]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [MapToApiVersion(1)]
        public async Task<ActionResult<BaseResponse>> HandleAsync ([FromBody] CreateDepartmentDTO departmentDTO)
        {
            var response = await _mediator.Send(new CreateDepartmentCommand(){DepartmentDTO = departmentDTO});
            return Ok(response);
        }
    }
}