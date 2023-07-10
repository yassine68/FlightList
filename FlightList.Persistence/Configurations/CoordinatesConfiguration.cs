using FlightList.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlightList.Persistence.Configurations;

public class CoordinatesConfiguration : IEntityTypeConfiguration<Coordinates>
{
    public void Configure(EntityTypeBuilder<Coordinates> builder)
    {
        builder.HasKey(x => x.Id);
        builder.ToTable(nameof(Coordinates));
    }
}