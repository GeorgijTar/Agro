using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Agro.DAL.Sql;

public static class Registrator
{
    public static IServiceCollection AddAgroDbMySql(this IServiceCollection services, string ConnectionString)
    {
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 28));
        services.AddDbContext<AgroDB>(opt => opt
            .UseMySql(ConnectionString, serverVersion,
                o => o.MigrationsAssembly(typeof(Registrator).Assembly.FullName)));


        return services;
    }
}
