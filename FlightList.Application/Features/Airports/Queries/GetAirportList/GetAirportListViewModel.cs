using FlightList.Application.Features.Flights.Dtos;

namespace FlightList.Application.Features.Airports.Queries.GetAirportList;

public class GetAirportListViewModel
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
    public CoordinatesDto? Coordinates { get; set; }
}
