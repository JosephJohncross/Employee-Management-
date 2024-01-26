using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.Versioning;
using EmployeeManagement.Application.DTOs.Department;
using EmployeeManagement.Application.Features.Department.Queries.GetAllDepartment;
using EmployeeManagement.Application.Response;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.EndpointClasses.Department
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/departments")]
    public class GetAllDepartment : ControllerBase
    {
        private readonly ISender _mediator;
        public GetAllDepartment(ISender mediator) => _mediator = mediator;
        
        /// <summary>
        /// Gets all department in an organization
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetAllDepartment")]
        [Description("Returns all department in the organization")]
        [SwaggerOperation(Tags = new[] { "Department"})]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [MapToApiVersion(1)]
        public async Task<ActionResult<BaseResponse<GetDepartmentDTO[]>>> HandleAsync ()
        {
            var response = await _mediator.Send(new GetAllDepartmentQuery());
            return Ok(response);
        }
    }
}