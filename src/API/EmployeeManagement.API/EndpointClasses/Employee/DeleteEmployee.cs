using EmployeeManagement.Application.Features.Employee.Commands;

namespace EmployeeManagement.API.EndpointClasses.Employee
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    // [ApiExplorerSettings(GroupName = "EmployeeManagementEmployee")]
    public class DeleteEmployee : ControllerBase
    {
        private readonly ISender _sender;
        public DeleteEmployee(ISender sender) => _sender = sender;
     
        [HttpDelete("/employees/delete", Name = "DeleteEmployee")]
        [Description("Deletes an employee")]
        [SwaggerOperation(Tags = new[] { "Employee" })]
        public async Task<ActionResult> HandleAsync([FromBody] Guid employeeId)
        {
            var deleteEmployeeCommand = new DeleteEmployeeCommand(){EmployeeId = employeeId};
            var result = await _sender.Send(deleteEmployeeCommand);
            return Ok(result);
        }
    }
}