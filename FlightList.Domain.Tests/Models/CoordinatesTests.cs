using FluentAssertions;

namespace FlightList.Domain.Tests.Models
{
    [TestClass]
    public partial class CoordinatesTests
    {
        [TestMethod]
        public void Coordinates_Should_Have_Valid_Properties()
        {
            // Arrange
            var coordinates = new Coordinates()
            {
                // Act
                Latitude = 123.45,
                Longitude = -67.89
            };

            // Assert
            coordinates.Latitude.Should().Be(123.45);
            coordinates.Longitude.Should().Be(-67.89);
        }
    }
}