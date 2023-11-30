
namespace EmployeeManagement.API.EndpointClasses.Employee
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class AllEmployee : ControllerBase
    {
        [HttpGet("/api/employees", Name = "AllEmployees")]
        [Description("Returns all employee of the company")]
        [SwaggerOperation(Tags = new[] { "Employee" })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult HandleAsync()
        {
            return Ok();
        }
    }
}