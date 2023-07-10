using FlightList.Application.Features.Flights.Dtos;

namespace FlightList.Application.Features.Flights.Queries.GetFlightDetail;

public class GetFlightDetailViewModel
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public DepartureAirportDto? DepartureAirport { get; set; }
    public ArrivalAirportDto? ArrivalAirport { get; set; }
}