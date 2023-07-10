using FlightList.Client.BlazorWA.Models;

namespace FlightList.Client.BlazorWA.Services;

public interface IAirportService
{
    Task<IEnumerable<AirportListRessource>?> GetAllAsync();
}
