using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Application.Features.Department.Queries.GetAllDepartment;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.EndpointClasses.Department
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class GetAllDepartment : ControllerBase
    {
        private readonly ISender _mediator;
        public GetAllDepartment(ISender mediator) => _mediator = mediator;
        
        [HttpGet("/departments", Name = "GetAllDepartment")]
        [Description("Returns all department in the organization")]
        [SwaggerOperation(Tags = new[] { "Department"})]
        public async Task<ActionResult> HandleAsync ()
        {
            var response = await _mediator.Send(new GetAllDepartmentQuery());
            return Ok(response);
        }
    }
}