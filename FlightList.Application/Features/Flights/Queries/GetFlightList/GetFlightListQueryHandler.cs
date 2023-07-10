using AutoMapper;
using FlightList.Application.Contracts;
using MediatR;

namespace FlightList.Application.Features.Flights.Queries.GetFlightList;

public class GetFlightListQueryHandler : IRequestHandler<GetFlightsListQuery, List<GetFlightsListViewModel>>
{
    private readonly IFlightRepository _flightRepository;
    private readonly IMapper _mapper;

    public GetFlightListQueryHandler(IFlightRepository flightRepository, IMapper mapper)
    {
        this._flightRepository = flightRepository;
        this._mapper = mapper;
    }

    public async Task<List<GetFlightsListViewModel>> Handle(GetFlightsListQuery request, CancellationToken cancellationToken)
    {
        var allFlights = await _flightRepository.GetAllFlightAsync(includeAirports: true);
        var mappData = _mapper.Map<List<GetFlightsListViewModel>>(allFlights);

        mappData = mappData.Select(o =>
        {
            o.Distance = _flightRepository.CalculateDistance(o.DepartureAirport!.Coordinates!.Latitude, o.DepartureAirport.Coordinates.Longitude,
                                                             o.ArrivalAirport!.Coordinates!.Latitude, o.ArrivalAirport.Coordinates.Longitude);

            return o;
        }).ToList();
        return mappData;
    }
}