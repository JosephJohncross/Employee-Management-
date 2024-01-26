using System.Reflection;
using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Asp.Versioning.Builder;
using EmployeeManagement.Application;
using EmployeeManagement.Infrastructure;
using EmployeeManagement.Infrastructure.Middelwares.GlobalExceptionHandlingMiddleware;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(config =>
{
    config.ReturnHttpNotAcceptable = true;
})
.AddXmlDataContractSerializerFormatters()
;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApiVersioning(setupAction =>
{
    setupAction.DefaultApiVersion = new ApiVersion(1, 0);
    setupAction.ReportApiVersions = true;
    setupAction.AssumeDefaultVersionWhenUnspecified = true;
    setupAction.ApiVersionReader = new UrlSegmentApiVersionReader();
})
.AddMvc()
.AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VV";
    options.SubstituteApiVersionInUrl = true;
});

var apiVersionDescriptionProvider =
    builder.Services.BuildServiceProvider()
    .GetService<IApiVersionDescriptionProvider>();

builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();

    foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
    {
        options.SwaggerDoc(description.GroupName, new () {
            Contact = new () {
                Email = "josephibochi2@gmail.com",
                Name = "Joseph Ibochi",
                Url = new Uri("https://linkedin/joseph-ibochi")
            },
            Description = "Through this API, you can manage all information of an organization department and employee",
            Version = description.ApiVersion.ToString(),
            Title = "Employee Management",
            License = new () {
                Name = "MIT License",
                Url = new Uri("https://opensource.org/licenses/MIT")
            }
        });
    }

    // options.DocInclusionPredicate((documentName, apiDescription) => 
    // {
    //     var actionAApiVersion = apiDescription.ActionDescriptor.GetApiVersionMetadata(ApiVersionMapping.Explicit | ApiVersionMapping.Implicit);
    // });


    // var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml");
    // var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    foreach (var xmlFile in xmlFiles)
    {
        options.IncludeXmlComments(xmlFile);
    }
});

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureService(builder.Configuration);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(setupAction =>
    {
        foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
        {
            setupAction.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", $"Employee Management {description.GroupName.ToUpperInvariant()}");            
            // setupAction.RoutePrefix = $"api/{description.GroupName}";
        }
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
