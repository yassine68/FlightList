using AutoMapper;
using FlightList.Application.Contracts;
using MediatR;

namespace FlightList.Application.Features.Airports.Queries.GetAirportList;

public class GetAirportListQueryHandler : IRequestHandler<GetAirportListQuery, List<GetAirportListViewModel>>
{
    private readonly IAirportRepository _airportRepository;
    private readonly IMapper _mapper;

    public GetAirportListQueryHandler(IAirportRepository airportRepository, IMapper mapper)
    {
        this._airportRepository = airportRepository;
        this._mapper = mapper;
    }

    public async Task<List<GetAirportListViewModel>> Handle(GetAirportListQuery request, CancellationToken cancellationToken)
    {
        var airports = await _airportRepository.GetAllAirportAsync(true);
        return _mapper.Map<List<GetAirportListViewModel>>(airports);
    }
}