using EmployeeManagement.Application.Features.Department.Queries.GetDepartmentById;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.EndpointClasses.Department
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class GetDepartmentById : ControllerBase
    {
        private readonly IMediator _mediator;
        public GetDepartmentById(IMediator mediator) => _mediator = mediator;

        [HttpGet("/departments/{departmentId:int}", Name = "GetDepartmentById")]
        [Description("Returns a department")]
        [SwaggerOperation(Tags = new[] { "Department"})]
        public async Task<ActionResult> HandleAsync (int departmentId)
        {
            var response = await _mediator.Send(new GetDepartmentByIdQuery(){DepartmentId = departmentId});
            return Ok(response);
        }
    }
}