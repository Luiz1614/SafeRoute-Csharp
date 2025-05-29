using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SafeRoute.Infraestructure.Data.AppData;

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
    }
}
