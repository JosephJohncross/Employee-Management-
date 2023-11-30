namespace EmployeeManagement.API.EndpointClasses.Employee
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class EmployeeById : ControllerBase
    {
        [HttpGet("/api/employees/{id:int}", Name = "GetEmployeeById")]
        [Description("Returns an Employee details based on Id")]
        [SwaggerOperation(Tags = new[] { "Employee" })]
        public ActionResult HandleAsync(int Id)
        {
            return Ok();
        }
    }
}