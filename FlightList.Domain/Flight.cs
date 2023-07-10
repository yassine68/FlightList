namespace FlightList.Domain;

public class Flight : BaseEntity
{
    public required string Name { get; set; } = null!;
    public required string DepartureAirportId { get; set; } = null!;
    public required string ArrivalAirportId { get; set; } = null!;
    public virtual Airport? DepartureAirport { get; set; }
    public virtual Airport? ArrivalAirport { get; set; }
    public bool Deleted { get; set; }
    public DateTime DateAdd { get; set; }
}