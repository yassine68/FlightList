using FlightList.Application.Contracts;
using FlightList.Application.Exceptions;
using MediatR;

namespace FlightList.Application.Features.Flights.Commands.DeleteFlight;

public class DeleteFlightCommandHandler : IRequestHandler<DeleteFlightCommand>
{
    private readonly IFlightRepository _flightRepository;

    public DeleteFlightCommandHandler(IFlightRepository flightRepository)
    {
        this._flightRepository = flightRepository;
    }

    public async Task<Unit> Handle(DeleteFlightCommand request, CancellationToken cancellationToken)
    {
        var flight = await _flightRepository.GetByIdAsync(request.FlightId);
        if (flight is null)
        {
            throw new FlightException("The Flight is not Found.");
        }

        flight.Deleted = true;
        await _flightRepository.UpdateAsync(flight);

        return Unit.Value;
    }
}