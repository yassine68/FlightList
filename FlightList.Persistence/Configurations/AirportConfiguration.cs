using FlightList.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlightList.Persistence.Configurations;
public class AirportConfiguration : IEntityTypeConfiguration<Airport>
{
    public void Configure(EntityTypeBuilder<Airport> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Code).HasMaxLength(10).IsRequired();

        builder.HasIndex(x => x.Code).IsUnique();

        builder.Property(x => x.CoordinatesId).IsRequired();

        builder.HasOne(x => x.Coordinates)
            .WithOne(x => x.Airport)
            .HasForeignKey<Airport>(x => x.CoordinatesId);

        builder.ToTable("Airports");
    }
}
