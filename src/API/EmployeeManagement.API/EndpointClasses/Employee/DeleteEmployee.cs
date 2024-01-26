using Asp.Versioning;
using EmployeeManagement.Application.Features.Employee.Commands;

namespace EmployeeManagement.API.EndpointClasses.Employee
{
    [ApiController]
    [ApiVersion("1.0")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Route("api/v{v:apiVersion}/employees/delete")]
    // [ApiExplorerSettings(GroupName = "EmployeeManagementEmployee")]
    public class DeleteEmployee : ControllerBase
    {
        private readonly ISender _sender;
        public DeleteEmployee(ISender sender) => _sender = sender;
     
        /// <summary>
        /// Deletes an employee record from an organization
        /// </summary>
        /// <param name="employeeId">Id of the employee to be deleted</param>
        /// <returns></returns>
        [HttpDelete(Name = "DeleteEmployee")]
        [Description("Deletes an employee")]
        [SwaggerOperation(Tags = new[] { "Employee" })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> HandleAsync([FromBody] Guid employeeId)
        {
            var deleteEmployeeCommand = new DeleteEmployeeCommand(){EmployeeId = employeeId};
            var result = await _sender.Send(deleteEmployeeCommand);
            return Ok(result);
        }
    }
}