using FlightList.Application.Contracts;
using FlightList.Domain;
using Microsoft.EntityFrameworkCore;

namespace FlightList.Persistence.Repositories;

public class FlightRepository : BaseRepository<Flight>, IFlightRepository
{

    public FlightRepository(FlightDbContext flightDbContext) : base(flightDbContext)
    {

    }
    public double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
    {
        const double earthRadiusKm = 6371;

        var dLat = (lat2 - lat1) * Math.PI / 180;
        var dLon = (lon2 - lon1) * Math.PI / 180;

        var lat1Rad = lat1 * Math.PI / 180;
        var lat2Rad = lat2 * Math.PI / 180;

        var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(lat1Rad) * Math.Cos(lat2Rad);
        var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

        return earthRadiusKm * c;
    }

    public async Task<IReadOnlyList<Flight>> GetAllFlightAsync(bool includeAirports)
    {
        if (includeAirports)
        {
            return await _dbContext.Flights.Include(o => o.DepartureAirport).ThenInclude(o => o!.Coordinates)
                                           .Include(o => o.ArrivalAirport).ThenInclude(o => o!.Coordinates)
                                           .ToListAsync();
        }
        return await _dbContext.Flights.ToListAsync();
    }

    public async Task<Flight?> GetFlightByIdAsync(string id, bool includeAirports = false)
    {
        if (includeAirports)
        {
            return await _dbContext.Flights.Include(o => o.DepartureAirport).ThenInclude(o => o!.Coordinates)
                                           .Include(o => o.ArrivalAirport).ThenInclude(o => o!.Coordinates)
                                           .SingleOrDefaultAsync(o => o.Id.Equals(id));
        }
        return await _dbContext.Flights.FindAsync(id);
    }
}