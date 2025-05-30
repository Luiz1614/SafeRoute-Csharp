using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SafeRoute.Application;
using SafeRoute.Application.Services;
using SafeRoute.Application.Services.Interfaces;
using SafeRoute.Infraestructure.Data.AppData;
using SafeRoute.Infraestructure.Data.Repositories;
using SafeRoute.Infraestructure.Data.Repositories.Interfaces;
using SafeRoute.Infraestructure.Mappings;

namespace SafeRoute.Ioc;

public class Bootstrap
{
    public static void Start(IServiceCollection service, IConfiguration configuration)
    {
        service.AddDbContext<ApplicationContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("Oracle");
            options.UseOracle(connectionString);
        });

        service.AddScoped<IUserRepository, UserRepository>();
        service.AddScoped<IUserService, UserService>();

        service.AddScoped<IClimaticEventRepository, ClimaticEventRepository>();
        service.AddScoped<IClimaticEventService, ClimaticEventService>();

        service.AddScoped<ISafeResourceRepository, SafeResourceRepository>();
        service.AddScoped<ISafeResourceService, SafeResourceService>();

        service.AddAutoMapper(typeof(MapperProfile));
    }
}
