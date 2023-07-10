using MediatR;

namespace FlightList.Application.Features.Flights.Queries.GetFlightList;

public class GetFlightsListQuery : IRequest<List<GetFlightsListViewModel>>
{
}