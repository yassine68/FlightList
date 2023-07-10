namespace FlightList.Domain;

public class Coordinates : BaseEntity
{
    public required double Latitude { get; set; }
    public required double Longitude { get; set; }
    public virtual Airport? Airport { get; set; }
}