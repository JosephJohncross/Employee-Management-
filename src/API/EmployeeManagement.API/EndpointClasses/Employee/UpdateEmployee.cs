namespace EmployeeManagement.API.EndpointClasses.Employee
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class UpdateEmployee : ControllerBase
    {
        [HttpPatch("/employees/update", Name = "UpdateEmployee")]
        [Description("Update an employee info")]
        [SwaggerOperation(Tags = new[] { "Employee" })]
        public ActionResult HandleAsync()
        {
            return Ok();
        }
    }
}