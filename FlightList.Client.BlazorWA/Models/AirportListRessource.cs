namespace FlightList.Client.BlazorWA.Models;

public class AirportListRessource
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
    public CoordinatesRessource? Coordinates { get; set; }
}
