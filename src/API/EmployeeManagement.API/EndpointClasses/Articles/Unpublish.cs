using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EmployeeManagement.API.EndpointClasses.Articles
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class Unpublish : ControllerBase
    {
        [HttpGet("api/authors", Name = "GetAllAuthors")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(
        Tags = new[] { "Articles" },
        Description = "Unpublish an article"
    )]
        public ActionResult HandleAsync()
        {
            return Ok();
        }


    }
}