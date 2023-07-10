using FlightList.Client.BlazorWA.Models;
using Microsoft.AspNetCore.Components;

namespace FlightList.Client.BlazorWA.Pages;

public partial class Flights
{

    [Inject]
    private IFlightService _flightService { get; set; } = null!;
    public IEnumerable<FlightListRessource> _flightLists { get; set; } = new List<FlightListRessource>();

    protected override async Task OnInitializedAsync()
    {
        var apiFlights = await _flightService.AllAsync();

        if (apiFlights is not null && apiFlights.Any())
        {
            _flightLists = apiFlights;
        }
    }
}