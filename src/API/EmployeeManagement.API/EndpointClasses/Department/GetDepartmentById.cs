using Asp.Versioning;
using EmployeeManagement.Application.DTOs.Department;
using EmployeeManagement.Application.Features.Department.Queries.GetDepartmentById;
using EmployeeManagement.Application.Response;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.EndpointClasses.Department
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/departments/{departmentId}")]
    public class GetDepartmentById : ControllerBase
    {
        private readonly IMediator _mediator;
        public GetDepartmentById(IMediator mediator) => _mediator = mediator;
        
        /// <summary>
        /// Gets a department by its id
        /// </summary>
        /// <param name="departmentId">Id of the department</param>
        /// <returns></returns>
        [HttpGet(Name = "GetDepartmentById")]
        [Description("Returns a department")]
        [SwaggerOperation(Tags = new[] { "Department"})]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        // [MapToApiVersion(1)]
        public async Task<ActionResult<BaseResponse<GetDepartmentDTO>>> HandleAsync (Guid departmentId)
        {
            var response = await _mediator.Send(new GetDepartmentByIdQuery(){DepartmentId = departmentId});
            return Ok(response);
        }
    }
}