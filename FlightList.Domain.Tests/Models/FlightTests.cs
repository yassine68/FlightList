using FluentAssertions;

namespace FlightList.Domain.Tests.Models
{
    public partial class CoordinatesTests
    {
        [TestClass]
        public class FlightTests
        {
            [TestMethod]
            public void Flight_Should_Have_Valid_Properties()
            {
                // Arrange
                var flight = new Flight()
                {
                    // Act
                    Name = "Test Flight",
                    DepartureAirportId = "1",
                    ArrivalAirportId = "2"
                };

                // Assert
                flight.Name.Should().Be("Test Flight");
                flight.DepartureAirportId.Should().Be("1");
                flight.ArrivalAirportId.Should().Be("2");
            }
        }
    }
}