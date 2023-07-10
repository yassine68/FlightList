using MediatR;

namespace FlightList.Application.Features.Flights.Commands.DeleteFlight;

public class DeleteFlightCommand : IRequest
{
    public required string FlightId { get; set; } = null!;
}