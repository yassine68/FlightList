using FlightList.Client.BlazorWA.Models;
using Microsoft.AspNetCore.Components;

namespace FlightList.Client.BlazorWA.Pages;

public partial class Flightdetails
{

    protected string Message = string.Empty;

    [Inject]
    private IAirportService _airportService { get; set; } = null!;

    [Inject]
    private IFlightService _flightService { get; set; } = null!;

    [Inject]
    private NavigationManager navigationManager { get; set; } = null!;
    public FlightListRessourceDetail model { get; set; } = new();

    [Parameter]
    public string? Id { get; set; }

    public int Counter { get; set; } = 0;


    protected override async Task OnInitializedAsync()
    {
        if (string.IsNullOrEmpty(Id))
        {
            // adding a new flight
            model.AirportListRessources = await _airportService.GetAllAsync();
            if (model.AirportListRessources is not null && model.AirportListRessources.Any())
            {
                model.ArrivalAirportId = model.AirportListRessources.ElementAt(0).Id;
                model.DepartureAirportId = model.AirportListRessources.ElementAt(0).Id;
            }
        }

        else
        {
            // updating a new flight

            var flight = await _flightService.GetFlightAsync(Id);

            if (flight is not null)
            {
                model.Name = flight.Name;
                model.DepartureAirportId = flight.DepartureAirport!.Id;
                model.ArrivalAirportId = flight.ArrivalAirport!.Id;
                model.Id = flight.Id;
                model.AirportListRessources = await _airportService.GetAllAsync();
            }
        }

    }

    protected void HandleFailedRequest()
    {
        Message = "Something went wrong, form not submited.";
    }

    protected void GoToFlights()
    {
        navigationManager.NavigateTo("/Flights");
    }

    protected async Task DeleteFlight()
    {
        if (!string.IsNullOrEmpty(Id))
        {
            var result = await _flightService.DeleteAsync(Id);

            if (result)
                navigationManager.NavigateTo("/Flights");
            else
                Message = "Something went wrong, flight not deleted.";
        }
    }
    protected async Task HandleValidRequest()
    {
        if (string.IsNullOrEmpty(Id))
        {
            // add flight
            var newFlight = new FlightRessource
            {
                ArrivalAirportId = model.ArrivalAirportId,
                DepartureAirportId = model.DepartureAirportId,
                Name = model.Name
            };

            await _flightService.AddAsync(newFlight);

            navigationManager.NavigateTo("/Flights");
        }
        else
        {
            var result = await _flightService.UpdateAsync(new UpdateFlightDto
            {
                ArrivalAirportId = model.ArrivalAirportId,
                DepartureAirportId = model.DepartureAirportId,
                Id = model.Id,
                Name = model.Name
            });

            if (!result)
                Message = "Something went wrong, flight not updated.";
            else
                navigationManager.NavigateTo("/Flights");
        }
    }

}
