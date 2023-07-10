using FlightList.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlightList.Persistence.Configurations;

public class FlightConfiguration : IEntityTypeConfiguration<Flight>
{
    public void Configure(EntityTypeBuilder<Flight> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(f => f.Name).HasMaxLength(100).IsRequired();

        builder.HasOne(x => x.DepartureAirport)
            .WithMany(x => x.DepartureAirportFlights)
            .HasForeignKey(x => x.DepartureAirportId)
            .HasPrincipalKey(o => o.Id);

        builder.HasOne(x => x.ArrivalAirport)
            .WithMany(x => x.ArrivalAirportFlights)
            .HasForeignKey(x => x.ArrivalAirportId)
            .HasPrincipalKey(o => o.Id);

        builder.Property(o => o.DateAdd).HasDefaultValue(DateTime.UtcNow);

        builder.HasQueryFilter(x => !x.Deleted);

        builder.ToTable("Flights");
    }
}
