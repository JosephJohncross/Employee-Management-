namespace EmployeeManagement.API.EndpointClasses.CustomEmployeeInfo
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class Update : ControllerBase
    {
        [HttpPatch("/api/custominfo/update", Name = "UpdateInfo")]
        [Description("Update a custom detail")]
        [SwaggerOperation(Tags = new[] { "CustomEmployeeInfo" })]
        public ActionResult HandleAsync()
        {
            return Ok();
        }
    }
}