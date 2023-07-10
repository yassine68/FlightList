using MediatR;

namespace FlightList.Application.Features.Airports.Queries.GetAirportList;

public class GetAirportListQuery : IRequest<List<GetAirportListViewModel>>
{
}