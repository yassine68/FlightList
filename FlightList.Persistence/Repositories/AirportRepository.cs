using FlightList.Application.Contracts;
using FlightList.Domain;
using Microsoft.EntityFrameworkCore;

namespace FlightList.Persistence.Repositories;

public class AirportRepository : BaseRepository<Airport>, IAirportRepository
{
    public AirportRepository(FlightDbContext flightDbContext) : base(flightDbContext)
    {
    }

    public async Task<IReadOnlyList<Airport>> GetAllAirportAsync(bool includeCoordinates)
    {
        return includeCoordinates ? await _dbContext.Airports.Include(o => o.Coordinates).ToListAsync() : await _dbContext.Airports.ToListAsync();
    }
}