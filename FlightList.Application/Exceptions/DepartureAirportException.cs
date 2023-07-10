using System.Runtime.Serialization;

namespace FlightList.Application.Exceptions;

[Serializable]
public class DepartureAirportException : Exception
{
    public DepartureAirportException() { }
    public DepartureAirportException(string message) : base(message) { }
    public DepartureAirportException(string message, Exception innerException) : base(message, innerException) { }
    protected DepartureAirportException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
