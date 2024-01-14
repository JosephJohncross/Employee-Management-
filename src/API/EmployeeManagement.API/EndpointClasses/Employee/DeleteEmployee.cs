namespace EmployeeManagement.API.EndpointClasses.Employee
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class DeleteEmployee : ControllerBase
    {
        [HttpDelete("/employees/delete", Name = "DeleteEmployee")]
        [Description("Deletes an employee")]
        [SwaggerOperation(Tags = new[] { "Employee" })]
        public ActionResult HandleAsync()
        {
            return Ok();
        }
    }
}