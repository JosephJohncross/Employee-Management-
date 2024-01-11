using System.Reflection;
using EmployeeManagement.Application.Features.Employee.Queries;
using EmployeeManagement.Application.Repository;
using EmployeeManagement.Infrastructure.Data;
using EmployeeManagement.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement.Infrastructure
{
    public static class InfrastructureServiceRegisteration
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options => {
                options.UseNpgsql(config.GetConnectionString("Default"), b => b.MigrationsAssembly("EmployeeManagement.Infrastructure"));
            });
            services.AddTransient<IEmployee<EmployeeDto>, EmployeeRepository>();
            
            return services;
        }
    }
}