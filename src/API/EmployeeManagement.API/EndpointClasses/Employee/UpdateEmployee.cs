using EmployeeManagement.Application.DTOs.Employee;
using EmployeeManagement.Application.Features.Employee.Commands.UpdateEmployeeCommand;

namespace EmployeeManagement.API.EndpointClasses.Employee
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class UpdateEmployee : ControllerBase
    {
        private readonly ISender _sender;
        public UpdateEmployee(ISender sender) => _sender = sender;

        [HttpPatch("/employees/update", Name = "UpdateEmployee")]
        [Description("Update an employee info")]
        [SwaggerOperation(Tags = new[] { "Employee" })]
        public  async Task<ActionResult >HandleAsync([FromBody] UpdateEmployeeDTO employee)
        {
            var updateEmployeeCommand = new UpdateEmployeeCommand(){employeeDTO = employee};
            var response = await _sender.Send(updateEmployeeCommand);
            if (response.Status){
                return Ok(response);
            }else{
                return BadRequest(response);
            }
        }
    }
}