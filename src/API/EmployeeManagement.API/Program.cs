using System.Reflection;
using Asp.Versioning;
using Asp.Versioning.Builder;
using EmployeeManagement.Application;
using EmployeeManagement.Infrastructure;
using EmployeeManagement.Infrastructure.Middelwares.GlobalExceptionHandlingMiddleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(config => {
    config.ReturnHttpNotAcceptable = true;
})
.AddXmlDataContractSerializerFormatters()
;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddApiVersioning(setupAction => {
    setupAction.DefaultApiVersion = new ApiVersion(1, 0);
    setupAction.ReportApiVersions = true;
    // setupAction.AssumeDefaultVersionWhenUnspecified = true;
    setupAction.ApiVersionReader = ApiVersionReader.Combine(
        new UrlSegmentApiVersionReader(),
        new HeaderApiVersionReader("X-Api-Version")
    );
})
.AddApiExplorer(options => {
    options.GroupNameFormat = "'v'V";
    options.SubstituteApiVersionInUrl = true;
});

builder.Services.AddSwaggerGen(options => {
        options.EnableAnnotations();

        options.SwaggerDoc("v1", new () {
            Contact = new () {
                Email = "josephibochi2@gmail.com",
                Name = "Joseph Ibochi",
                Url = new Uri("https://linkedin/joseph-ibochi")
            },
            Description = "Through this API, you can manage all information of an organization department and employee",
            Version = "v1",
            Title = "Employee Management",
            License = new () {
                Name = "MIT License",
                Url = new Uri("https://opensource.org/licenses/MIT")
            }
        });
        
        // options.SwaggerDoc("EmployeeManagementDepartment", new () {
        //     Contact = new () {
        //         Email = "josephibochi2@gmail.com",
        //         Name = "Joseph Ibochi",
        //         Url = new Uri("https://linkedin/joseph-ibochi")
        //     },
        //     Description = "Through this API, you can manage all information of an organization department",
        //     Version = "v1",
        //     Title = "Employee Management (Department)",
        //     License = new () {
        //         Name = "MIT License",
        //         Url = new Uri("https://opensource.org/licenses/MIT")
        //     }
        // });

        // options.SwaggerDoc("EmployeeManagementEmployee", new () {
        //     Contact = new () {
        //         Email = "josephibochi2@gmail.com",
        //         Name = "Joseph Ibochi",
        //         Url = new Uri("https://linkedin/joseph-ibochi")
        //     },
        //     Description = "Through this API, you can manage all information of an organization employee",
        //     Version = "v1",
        //     Title = "Employee Management (Employee)",
        //     License = new () {
        //         Name = "MIT License",
        //         Url = new Uri("https://opensource.org/licenses/MIT")
        //     }
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
    app.UseSwaggerUI(setupAction => {
        setupAction.SwaggerEndpoint("/swagger/v1/swagger.json", "Employee Management");
        // setupAction.SwaggerEndpoint("/swagger/EmployeeManagementEmployee/swagger.json", "Employee Management (Employee)");
        // setupAction.SwaggerEndpoint("/swagger/EmployeeManagementDepartment/swagger.json", "Employee Management (Department)");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
