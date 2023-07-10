using FlightList.Application.Features.Flights.Commands.CreateFlight;
using FlightList.Application.Features.Flights.Commands.DeleteFlight;
using FlightList.Application.Features.Flights.Commands.UpdateFlight;
using FlightList.Application.Features.Flights.Queries.GetFlightDetail;
using FlightList.Application.Features.Flights.Queries.GetFlightList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FlightList.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FlightController : ControllerBase
{
    private readonly IMediator _mediator;

    public FlightController(IMediator mediator)
    {
        this._mediator = mediator;
    }

    [HttpGet]
    [ActionName("GellAllFlight")]
    public async Task<ActionResult<List<GetFlightsListViewModel>>> GellAllFlightAsync()
    {
        try
        {
            var dtos = await _mediator.Send(new GetFlightsListQuery());
            return Ok(dtos);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    [HttpGet("{id}", Name = "GetFligthById")]
    public async Task<ActionResult<GetFlightDetailViewModel>> GetFligthByIdAsync(string id)
    {
        try
        {
            var getEventDetailQuery = new GetFlightDetailQuery() { FlightId = id };
            return Ok(await _mediator.Send(getEventDetailQuery));
        }
        catch (Exception ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }

    [HttpPost(Name = "AddFligth")]
    public async Task<ActionResult<string>> Create([FromBody] CreateFlightCommad createFligthCommand)
    {
        try
        {
            await _mediator.Send(createFligthCommand);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }

    [HttpPut(Name = "UpdateFligth")]
    public async Task<ActionResult> UpdateAsync([FromBody] UpdateFlightCommand updateFligthCommand)
    {
        try
        {
            await _mediator.Send(updateFligthCommand);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }

    [HttpDelete("{id}", Name = "DeleteFligth")]
    public async Task<ActionResult> DeleteAsync(string id)
    {
        try
        {
            var deleteFligthCommand = new DeleteFlightCommand() { FlightId = id };
            await _mediator.Send(deleteFligthCommand);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }


}
