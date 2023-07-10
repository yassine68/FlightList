using MediatR;

namespace FlightList.Application.Features.Flights.Commands.CreateFlight;

public class CreateFlightCommad : IRequest<string>
{
    public required string Name { get; set; } = null!;
    public required string DepartureAirportId { get; set; } = null!;
    public required string ArrivalAirportId { get; set; } = null!;
}