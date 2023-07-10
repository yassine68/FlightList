using FluentValidation;

namespace FlightList.Application.Features.Flights.Commands.UpdateFlight;

public class UpdateCommandValidator : AbstractValidator<UpdateFlightCommand>
{
    public UpdateCommandValidator()
    {
        RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("The flight id cannot be empty.");
        RuleFor(x => x.Name).NotNull().MaximumLength(100).NotEmpty().WithMessage("The flight name cannot be empty.");
        RuleFor(x => x.DepartureAirportId).NotNull().NotEmpty().WithMessage("Please select the departure airport.");
        RuleFor(x => x.ArrivalAirportId).NotNull().NotEmpty().WithMessage("Please select the arrival airport.");
    }
}