using FlightList.Application.Features.Airports.Queries.GetAirportList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FlightList.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AirportController : ControllerBase
{
    private readonly IMediator _mediator;

    public AirportController(IMediator mediator)
    {
        this._mediator = mediator;
    }

    [HttpGet]
    [ActionName("GellAllAirport")]
    public async Task<ActionResult<List<GetAirportListViewModel>>> GellAllAirportAsync()
    {
        try
        {
            var dtos = await _mediator.Send(new GetAirportListQuery());
            return Ok(dtos);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}