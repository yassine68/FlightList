using FlightList.Domain;

namespace FlightList.Application.Features.Flights.Dtos;

public class CoordinatesDto
{
    public string Id { get; set; } = null!;
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
