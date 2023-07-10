using AutoMapper;
using FlightList.Application.Contracts;
using MediatR;

namespace FlightList.Application.Features.Flights.Queries.GetFlightDetail;

public class GetFlightDetailQueryHanlder : IRequestHandler<GetFlightDetailQuery, GetFlightDetailViewModel>
{
    private readonly IFlightRepository _flightRepository;
    private readonly IMapper _mapper;

    public GetFlightDetailQueryHanlder(IFlightRepository flightRepository, IMapper mapper)
    {
        this._flightRepository = flightRepository;
        this._mapper = mapper;
    }
    public async Task<GetFlightDetailViewModel> Handle(GetFlightDetailQuery request, CancellationToken cancellationToken)
    {
        var flight = await _flightRepository.GetFlightByIdAsync(
            id: request.FlightId,
            includeAirports: true);

        return _mapper.Map<GetFlightDetailViewModel>(flight);
    }
}