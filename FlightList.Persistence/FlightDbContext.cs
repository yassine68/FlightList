using FlightList.Domain;
using FlightList.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace FlightList.Persistence;

public class FlightDbContext : DbContext
{
    public DbSet<Flight> Flights { get; set; }
    public DbSet<Airport> Airports { get; set; }
    public DbSet<Coordinates> Coordinates { get; set; }

    public FlightDbContext(DbContextOptions<FlightDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new AirportConfiguration());
        modelBuilder.ApplyConfiguration(new FlightConfiguration());
        modelBuilder.ApplyConfiguration(new CoordinatesConfiguration());

        modelBuilder.SeedData();

        foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(o => o.GetForeignKeys()))
        {
            foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}
