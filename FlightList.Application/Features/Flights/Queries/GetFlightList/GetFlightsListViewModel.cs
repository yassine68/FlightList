using FlightList.Application.Features.Flights.Dtos;

namespace FlightList.Application.Features.Flights.Queries.GetFlightList;

public class GetFlightsListViewModel
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public double Distance { get; set; }
    public DateTime DateAdd { get; set; }
    public DepartureAirportDto? DepartureAirport { get; set; }
    public ArrivalAirportDto? ArrivalAirport { get; set; }
}