using FluentAssertions;

namespace FlightList.Domain.Tests.Models
{
    [TestClass]
    public class AirportTests
    {
        [TestMethod]
        public void Airport_Should_Have_Valid_Properties()
        {
            // Arrange
            var airport = new Airport()
            {
                // Act
                Name = "Test Airport",
                Code = "TST",
                CoordinatesId = "1",
            };

            // Assert
            airport.Name.Should().Be("Test Airport");
            airport.Code.Should().Be("TST");
            airport.CoordinatesId.Should().Be("1");
        }
    }
}