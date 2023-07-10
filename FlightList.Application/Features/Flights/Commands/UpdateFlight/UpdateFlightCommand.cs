using MediatR;

namespace FlightList.Application.Features.Flights.Commands.UpdateFlight;

public class UpdateFlightCommand : IRequest
{
    public required string Id { get; set; } = null!;
    public required string Name { get; set; } = null!;
    public required string DepartureAirportId { get; set; } = null!;
    public required string ArrivalAirportId { get; set; } = null!;
}