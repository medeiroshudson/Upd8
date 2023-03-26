using Upd8.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Upd8.Infra;

public static class DependencyInjection
{
    public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
    {
        var connectonString = configuration.GetConnectionString("Upd8");
        services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectonString));

        return services;
    }
}
