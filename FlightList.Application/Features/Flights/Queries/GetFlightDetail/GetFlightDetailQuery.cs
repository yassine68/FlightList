using MediatR;

namespace FlightList.Application.Features.Flights.Queries.GetFlightDetail;

public class GetFlightDetailQuery : IRequest<GetFlightDetailViewModel>
{
    public required string FlightId { get; set; } = null!;
}