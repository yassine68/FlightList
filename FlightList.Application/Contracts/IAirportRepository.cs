using FlightList.Domain;

namespace FlightList.Application.Contracts;

public interface IAirportRepository : IAsyncRepository<Airport>
{
    Task<IReadOnlyList<Airport>> GetAllAirportAsync(bool includeCoordinates = false);
}