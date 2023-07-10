using FlightList.Application.Features.Airports.Queries.GetAirportList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace FlightList.Api.Controllers.Tests;

[TestClass]
public class AirportControllerTests
{
    private AirportController _airportController = null!;
    private Mock<IMediator> _mediatorMock = null!;

    [TestInitialize]
    public void TestInitialize()
    {
        _mediatorMock = new Mock<IMediator>();
        _airportController = new AirportController(_mediatorMock.Object);
    }

    [TestMethod]
    public async Task GellAllAirportAsync_ReturnsOkResultWithAirportList()
    {
        // Arrange
        var expectedAirports = new List<GetAirportListViewModel>
        {
            new GetAirportListViewModel { }
        };
        _mediatorMock.Setup(m => m.Send(It.IsAny<GetAirportListQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedAirports);

        // Act
        var result = await _airportController.GellAllAirportAsync();

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
        var okResult = result.Result as OkObjectResult;
        Assert.AreEqual(expectedAirports, okResult!.Value);
    }

    [TestMethod]
    public async Task GellAllAirportAsync_ReturnsBadRequestResultWhenExceptionThrown()
    {
        // Arrange
        string errorMessage = "An error occurred.";
        _mediatorMock.Setup(m => m.Send(It.IsAny<GetAirportListQuery>(), It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception(errorMessage));

        // Act
        var result = await _airportController.GellAllAirportAsync();

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result.Result, typeof(BadRequestObjectResult));
        var badRequestResult = result.Result as BadRequestObjectResult;
        Assert.AreEqual(errorMessage, badRequestResult!.Value);
    }
}
