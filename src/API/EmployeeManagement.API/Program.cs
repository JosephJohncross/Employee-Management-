using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using EmployeeManagement.Application;
using EmployeeManagement.Infrastructure;
using EmployeeManagement.Infrastructure.Middelwares.GlobalExceptionHandlingMiddleware;
using Serilog;
using HealthChecks.UI.Core;
using Microsoft.OpenApi.Models;

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

builder.Services.AddHealthChecks()
                .AddNpgSql(builder.Configuration.GetConnectionString("Default"));

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

    var xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml");
    foreach (var xmlFile in xmlFiles)
    {
        options.IncludeXmlComments(xmlFile);
    }

     // Add custom operation for health check
     options.SwaggerDoc("health", new OpenApiInfo { Title = "Health Check", Version = "v1" });
     options.DocumentFilter<HealthDocumentFilter>();
});

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureService(builder.Configuration);
builder.Services.AddLogging();

builder.Host.UseSerilog((context, loggerConfig) => {
    loggerConfig.ReadFrom.Configuration(context.Configuration);
});

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

app.UseHealthChecks("/health");

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseSerilogRequestLogging();

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
