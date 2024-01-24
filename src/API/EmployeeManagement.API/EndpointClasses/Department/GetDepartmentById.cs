using EmployeeManagement.Application.DTOs.Department;
using EmployeeManagement.Application.Features.Department.Queries.GetDepartmentById;
using EmployeeManagement.Application.Response;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.EndpointClasses.Department
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
    public class GetDepartmentById : ControllerBase
    {
        private readonly IMediator _mediator;
        public GetDepartmentById(IMediator mediator) => _mediator = mediator;
        
        /// <summary>
        /// Gets a department by its id
        /// </summary>
        /// <param name="departmentId">Id of the department</param>
        /// <returns></returns>
        [HttpGet("/departments/{departmentId}", Name = "GetDepartmentById")]
        [Description("Returns a department")]
        [SwaggerOperation(Tags = new[] { "Department"})]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BaseResponse<GetDepartmentDTO>>> HandleAsync (Guid departmentId)
        {
            var response = await _mediator.Send(new GetDepartmentByIdQuery(){DepartmentId = departmentId});
            return Ok(response);
        }
    }
}