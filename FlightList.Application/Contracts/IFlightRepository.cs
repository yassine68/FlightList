using FlightList.Domain;

namespace FlightList.Application.Contracts;

public interface IFlightRepository : IAsyncRepository<Flight>
{
    Task<IReadOnlyList<Flight>> GetAllFlightAsync(bool includeAirports);
    Task<Flight?> GetFlightByIdAsync(string id, bool includeAirports = false);
    double CalculateDistance(double lat1, double lon1, double lat2, double lon2);
}