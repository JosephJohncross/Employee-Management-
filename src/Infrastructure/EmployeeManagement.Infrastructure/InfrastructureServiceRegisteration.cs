using EmployeeManagement.Application.Contracts.Infrastructure;
using EmployeeManagement.Infrastructure.Data;
using EmployeeManagement.Infrastructure.Middelwares.GlobalExceptionHandlingMiddleware;
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
            services.AddTransient(typeof(IEmployee<>), typeof(EmployeeRepository<>));
            services.AddTransient(typeof(IDepartmentRepository<>), typeof(DepartmentRepository<>));
            services.AddTransient<GlobalExceptionHandlingMiddleware>();
            
            return services;
        }
    }
}