using System.Runtime.Serialization;

namespace FlightList.Application.Exceptions;

[Serializable]
public class ArrivalAirportException : Exception
{
    public ArrivalAirportException() { }
    public ArrivalAirportException(string message) : base(message) { }
    public ArrivalAirportException(string message, Exception innerException) : base(message, innerException) { }
    protected ArrivalAirportException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
