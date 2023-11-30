namespace EmployeeManagement.API.EndpointClasses.CustomEmployeeInfo
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class Create : ControllerBase
    {
        [HttpPost("/api/custominfo/create", Name = "CreateInfo")]
        [Description("Delete a custom detail")]
        [SwaggerOperation(Tags = new[] { "CustomEmployeeInfo" })]
        public ActionResult HandleAsync()
        {
            return Ok();
        }
    }
}