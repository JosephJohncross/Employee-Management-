using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Swashbuckle.AspNetCore.Annotations;

namespace EmployeeManagement.API.EndpointClasses.Articles
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]

    public class Publish : ControllerBase
    {
        [HttpPut("api/articles/publish", Name = "PublishArticle")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [SwaggerOperation(
        Tags = new[] { "Articles" }
    )]
        public ActionResult HandleAsync()
        {
            return NoContent();
        }
    }
}