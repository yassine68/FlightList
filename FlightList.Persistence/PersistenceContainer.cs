using FlightList.Application.Contracts;
using FlightList.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FlightList.Persistence;

public static class PersistenceContainer
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<FlightDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("mssql1"));
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });

        services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IFlightRepository, FlightRepository>();
        services.AddScoped<IAirportRepository, AirportRepository>();

        using var scope = services.BuildServiceProvider().CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<FlightDbContext>();

        if (dbContext.Database.GetPendingMigrations().Any())
        {
            dbContext.Database.Migrate();
        }

        return services;
    }
}