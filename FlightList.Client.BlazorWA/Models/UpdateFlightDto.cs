namespace FlightList.Client.BlazorWA.Models;

public class UpdateFlightDto
{
    public required string Id { get; set; } = null!;
    public required string Name { get; set; } = null!;
    public required string DepartureAirportId { get; set; } = null!;
    public required string ArrivalAirportId { get; set; } = null!;
}
