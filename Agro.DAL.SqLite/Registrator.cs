using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Agro.DAL.SqLite;

public static class Registrator
{
    public static IServiceCollection AddAgroDbSqlite(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AgroDB>(opt => opt
            .UseSqlite(
                connectionString,
                o => o.MigrationsAssembly(typeof(Registrator).Assembly.FullName)));

        return services;
    }

    //public static IServiceCollection AddThoughtsDbSqliteFactory(this IServiceCollection services, string connectionString)
    //{
    //    services.AddDbContextFactory<AgroDB>(opt => opt
    //        .UseSqlite(
    //            connectionString,
    //            o => o.MigrationsAssembly(typeof(Registrator).Assembly.FullName)));


    //    return services;
    //}
}
