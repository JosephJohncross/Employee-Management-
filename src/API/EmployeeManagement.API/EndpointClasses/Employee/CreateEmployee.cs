namespace EmployeeManagement.API.EndpointClasses.Employee
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class CreateEmployee : ControllerBase
    {
        [HttpPost("/api/employees/create", Name = "CreateEmployee")]
        [Description("Creates a new employee")]
        [SwaggerOperation(Tags = new[] { "Employee" })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult HandleAsync()
        {
            return Ok();
        }
    }
}