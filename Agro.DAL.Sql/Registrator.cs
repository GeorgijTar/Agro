using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Agro.DAL.Sql;

public static class Registrator
{
    public static IServiceCollection AddAgroDbSqlServer(this IServiceCollection services, string ConnectionString)
    {
        services.AddDbContext<AgroDb>(opt => opt
            .UseSqlServer(
                ConnectionString,
                o => o.MigrationsAssembly(typeof(Registrator).Assembly.FullName)));
            

        return services;
    }
}
