using FlightList.Client.BlazorWA.Models;
using System.Text.Json;

namespace FlightList.Client.BlazorWA.Services;

public class AirportService : IAirportService
{
    private readonly HttpClient _httpClient;
    private string ApiUrl { get; set; }


    public AirportService(HttpClient httpClient, ApiSettings apiSettings)
    {
        this._httpClient = httpClient;
        ApiUrl = apiSettings.ApiUrl;
    }
    public async Task<IEnumerable<AirportListRessource>?> GetAllAsync()
    {
        try
        {
            var apiResponse = await _httpClient.GetStreamAsync($"{ApiUrl}api/Airport");
            var airportLists = await JsonSerializer.DeserializeAsync<IEnumerable<AirportListRessource>>(apiResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return airportLists;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error  :{ex.Message}");
            throw;
        }
    }
}
