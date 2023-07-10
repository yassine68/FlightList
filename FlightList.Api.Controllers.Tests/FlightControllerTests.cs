using FlightList.Application.Features.Flights.Commands.CreateFlight;
using FlightList.Application.Features.Flights.Commands.UpdateFlight;
using FlightList.Application.Features.Flights.Queries.GetFlightDetail;
using FlightList.Application.Features.Flights.Queries.GetFlightList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace FlightList.Api.Controllers.Tests;

[TestClass]
public class FlightControllerTests
{
    private FlightController _flightController = null!;
    private Mock<IMediator> _mediatorMock = null!;

    [TestInitialize]
    public void TestInitialize()
    {
        _mediatorMock = new Mock<IMediator>();
        _flightController = new FlightController(_mediatorMock.Object);
    }

    [TestMethod]
    public async Task GellAllFlightAsync_ReturnsOkResultWithFlightsList()
    {
        // Arrange
        var expectedFlights = new List<GetFlightsListViewModel>
        {
            new GetFlightsListViewModel {  }
        };
        _mediatorMock.Setup(m => m.Send(It.IsAny<GetFlightsListQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedFlights);

        // Act
        var result = await _flightController.GellAllFlightAsync();

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
        var okResult = result.Result as OkObjectResult;
        Assert.AreEqual(expectedFlights, okResult!.Value);
    }

    [TestMethod]
    public async Task GetFligthByIdAsync_ReturnsOkResultWithFlightDetail()
    {
        // Arrange
        var expectedFlightDetail = new GetFlightDetailViewModel { };
        _mediatorMock.Setup(m => m.Send(It.IsAny<GetFlightDetailQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedFlightDetail);

        // Act
        var result = await _flightController.GetFligthByIdAsync("flightId");

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
        var okResult = result.Result as OkObjectResult;
        Assert.AreEqual(expectedFlightDetail, okResult!.Value);
    }

    [TestMethod]
    public async Task Create_ReturnsOkResultWithGeneratedId()
    {
        // Arrange
        var createFlightCommand = new CreateFlightCommad
        {
            ArrivalAirportId = Guid.NewGuid().ToString(),
            DepartureAirportId = Guid.NewGuid().ToString(),
            Name = "TEST"
        };
        string generatedId = "generatedId";
        _mediatorMock.Setup(m => m.Send(It.IsAny<CreateFlightCommad>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(generatedId);

        // Act
        var result = await _flightController.Create(createFlightCommand);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
        var okResult = result.Result as OkObjectResult;
        Assert.AreEqual(generatedId, okResult!.Value);
    }

    [TestMethod]
    public async Task UpdateAsync_ReturnsNoContentResult()
    {
        // Arrange
        var updateFlightCommand = new UpdateFlightCommand
        {
            ArrivalAirportId = Guid.NewGuid().ToString(),
            DepartureAirportId = Guid.NewGuid().ToString(),
            Id = Guid.NewGuid().ToString(),
            Name = "TEST"
        };

        // Act
        var result = await _flightController.UpdateAsync(updateFlightCommand);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(NoContentResult));
    }

    [TestMethod]
    public async Task DeleteAsync_ReturnsNoContentResult()
    {
        // Arrange
        string flightId = "flightId";

        // Act
        var result = await _flightController.DeleteAsync(flightId);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(NoContentResult));
    }
}
