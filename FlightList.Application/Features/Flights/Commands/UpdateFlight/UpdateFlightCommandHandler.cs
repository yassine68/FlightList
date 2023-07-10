using AutoMapper;
using FlightList.Application.Contracts;
using FlightList.Application.Exceptions;
using FlightList.Domain;
using MediatR;

namespace FlightList.Application.Features.Flights.Commands.UpdateFlight
{
    public class UpdateFlightCommandHandler : IRequestHandler<UpdateFlightCommand>
    {
        private readonly IFlightRepository _flightRepository;
        private readonly IMapper _mapper;
        private readonly IAirportRepository _airportRepository;

        public UpdateFlightCommandHandler(IFlightRepository flightRepository, IMapper mapper, IAirportRepository airportRepository)
        {
            this._flightRepository = flightRepository;
            this._mapper = mapper;
            this._airportRepository = airportRepository;
        }

        public async Task<Unit> Handle(UpdateFlightCommand request, CancellationToken cancellationToken)
        {
            UpdateCommandValidator validator = new();
            var result = await validator.ValidateAsync(request);

            if (result.Errors.Any())
            {
                var errorMessages = result.Errors
                    .Select(failure => $"Property: {failure.PropertyName}, Error: {failure.ErrorMessage}");

                throw new ArgumentException($"Flight is not valid. Details: {string.Join(", ", errorMessages)}");
            }

            var departureAirport = await _airportRepository.GetByIdAsync(request.DepartureAirportId);
            if (departureAirport is null)
            {
                throw new DepartureAirportException("The Departure Airport is not Found.");
            }

            var arrivalAirport = await _airportRepository.GetByIdAsync(request.ArrivalAirportId);
            if (arrivalAirport is null)
            {
                throw new ArrivalAirportException("The Arrival Airport is not Found.");
            }

            var existFlight = await _flightRepository.GetByIdAsync(request.Id);
            if (existFlight is null)
            {
                throw new FlightException("The Flight is not Found.");
            }

            var flight = _mapper.Map<Flight>(request);

            await _flightRepository.UpdateAsync(flight);

            return Unit.Value;
        }
    }
}
