using Asp.Versioning;
using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.Features.Employee.Queries.GetEmployeeById;
using EmployeeManagement.Application.Response;

namespace EmployeeManagement.API.EndpointClasses.Employee
{
    [ApiController]
    [ApiVersion("1.0")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Route("api/v{v:apiVersion}/employees/{id}")]
    // [ApiExplorerSettings(GroupName = "EmployeeManagementEmployee")]
    public class EmployeeById : ControllerBase
    {
        public ISender _mediator { get; set; }
        public EmployeeById(ISender mediator) => _mediator = mediator;
        
        /// <summary>
        /// Returns an employee with the given id
        /// </summary>
        /// <param name="id">Id of employee to be returned</param>
        /// <returns></returns>
        [HttpGet(Name = "GetEmployeeById")]
        [Description("Returns an Employee details based on id")]
        [SwaggerOperation(Tags = new[] { "Employee" })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BaseResponse<EmployeeDto>>> HandleAsync(Guid id)
        {
            var getEmployeeById = new GetEmployeeByIdQuery() {EmployeeId = id};
            return getEmployeeById != null ? Ok (await _mediator.Send(getEmployeeById)) : NotFound();
        }
    }
}