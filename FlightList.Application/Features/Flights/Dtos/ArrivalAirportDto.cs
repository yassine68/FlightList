using FlightList.Domain;

namespace FlightList.Application.Features.Flights.Dtos;

public class ArrivalAirportDto
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
    public CoordinatesDto? Coordinates { get; set; }
}
