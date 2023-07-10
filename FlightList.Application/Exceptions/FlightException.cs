using System.Runtime.Serialization;

namespace FlightList.Application.Exceptions;

[Serializable]
public class FlightException : Exception
{
    public FlightException() { }
    public FlightException(string message) : base(message) { }
    public FlightException(string message, Exception innerException) : base(message, innerException) { }
    protected FlightException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}