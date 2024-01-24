using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Application.Features.Department.Commands.DeleteDepartmentCommand;
using EmployeeManagement.Application.Response;

namespace EmployeeManagement.API.EndpointClasses.Department
{
    [ApiController]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
    public class DeleteDepartment : ControllerBase
    {
        private readonly ISender _mediator;
        public DeleteDepartment(ISender mediator) => _mediator = mediator;
      
        /// <summary>
        /// Deletes a department from an organization
        /// </summary>
        /// <param name="departmenId">Id of department to delete</param>
        /// <returns></returns>
        [HttpDelete("/departments/delete", Name = "DeleteDepartment")]
        [Description("Deletes a department in the organization")]
        [SwaggerOperation(Tags = new[] { "Department"})]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BaseResponse>> HandleAsync ([FromBody] Guid departmenId)
        {
            var response = await _mediator.Send(new DeleteDepartmentCommand(){DepartmentId = departmenId});
            return Ok(response);
        }
    }
}