using FlightList.Client.BlazorWA.Models;

namespace FlightList.Client.BlazorWA.Services;

public interface IFlightService
{
    Task<IEnumerable<FlightListRessource>?> AllAsync();
    Task<FlightListRessource?> GetFlightAsync(string id);
    Task<string?> AddAsync(FlightRessource flightRessource);
    Task<bool> UpdateAsync(UpdateFlightDto updateFlightDto);
    Task<bool> DeleteAsync(string id);
}
