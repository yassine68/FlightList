namespace FlightList.Client.BlazorWA.Models;

public class FlightListRessource
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public double Distance { get; set; }
    public DateTime DateAdd { get; set; }

    public DepartureAirporRessource? DepartureAirport { get; set; }
    public ArrivalAirportRessource? ArrivalAirport { get; set; }
}

public class FlightListRessourceDetail
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string DepartureAirportId { get; set; } = null!;
    public string ArrivalAirportId { get; set; } = null!;
    public IEnumerable<AirportListRessource>? AirportListRessources { get; set; }
    public FlightListRessourceDetail()
    {
        AirportListRessources = new HashSet<AirportListRessource>();
    }
}

public class DepartureAirporRessource
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
    public CoordinatesRessource? Coordinates { get; set; }
}
public class ArrivalAirportRessource
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
    public CoordinatesRessource? Coordinates { get; set; }
}

public class CoordinatesRessource
{
    public string Id { get; set; } = null!;
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
