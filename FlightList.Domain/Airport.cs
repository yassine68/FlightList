namespace FlightList.Domain;

public class Airport : BaseEntity
{
    public required string Name { get; set; } = null!;
    public required string Code { get; set; } = null!;
    /// <summary>
    /// Foreign key referencing the GPS coordinates of the airport.
    /// </summary>
    public required string CoordinatesId { get; set; } = null!;
    public virtual Coordinates? Coordinates { get; set; }
    public virtual ICollection<Flight>? DepartureAirportFlights { get; set; }
    public virtual ICollection<Flight>? ArrivalAirportFlights { get; set; }
}