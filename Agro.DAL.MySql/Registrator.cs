using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Agro.DAL.MySql;

public static class Registrator
{
    public static IServiceCollection AddAgroDbMySql(this IServiceCollection services, string ConnectionString)
    {
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 28));
        services.AddDbContext<AgroDb>(opt => opt
            .UseMySql(ConnectionString, serverVersion,
                o => o.MigrationsAssembly(typeof(Registrator).Assembly.FullName).EnableRetryOnFailure(5))); //.UseLazyLoadingProxies()
        return services;
    }
}
