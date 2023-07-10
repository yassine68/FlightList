namespace FlightList.Client.BlazorWA.Models;

public class FlightRessource
{
    public required string Name { get; set; } = null!;
    public required string DepartureAirportId { get; set; } = null!;
    public required string ArrivalAirportId { get; set; } = null!;
}
