using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Application.Features.Department.Commands.DeleteDepartmentCommand;

namespace EmployeeManagement.API.EndpointClasses.Department
{
    [ApiController]
     [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class DeleteDepartment : ControllerBase
    {
        private readonly ISender _mediator;
        public DeleteDepartment(ISender mediator) => _mediator = mediator;
      
        [HttpDelete("/departments/delete", Name = "DeleteDepartment")]
        [Description("Deletes a department in the organization")]
        [SwaggerOperation(Tags = new[] { "Department"})]
        public async Task<ActionResult> HandleAsync ([FromBody] Guid departmenId)
        {
            var response = await _mediator.Send(new DeleteDepartmentCommand(){DepartmentId = departmenId});
            return Ok(response);
        }
    }
}