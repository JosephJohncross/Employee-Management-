using System.Reflection;
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
builder.Services.AddSwaggerGen(options => {
        options.EnableAnnotations();

        options.SwaggerDoc("EmployeeManagement", new () {
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
        
        // var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml");
        // var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        foreach (var xmlFile in xmlFiles)
        {
            options.IncludeXmlComments(xmlFile);
        }
        
        // options.IncludeXmlComments(xmlPath);
});
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureService(builder.Configuration);
// builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(setupAction => {
        // setupAction.RoutePrefix = string.Empty;
        setupAction.SwaggerEndpoint("/swagger/EmployeeManagement/swagger.json", "Employee Management");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
