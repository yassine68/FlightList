using FlightList.Client.BlazorWA.Models;
using System.Text;
using System.Text.Json;

namespace FlightList.Client.BlazorWA.Services;

public class FlightService : IFlightService
{
    private readonly HttpClient _httpClient;
    private string ApiUrl { get; set; }

    public FlightService(HttpClient httpClient, ApiSettings apiSettings)
    {
        this._httpClient = httpClient;
        ApiUrl = apiSettings.ApiUrl;
    }
    public async Task<string?> AddAsync(FlightRessource flightRessource)
    {
        try
        {
            var itemJson = new StringContent(JsonSerializer.Serialize(flightRessource), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{ApiUrl}api/Flight", itemJson);
            if (response.IsSuccessStatusCode)
            {
                var fligthId = await response.Content.ReadAsStringAsync();
                return fligthId;
            }
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error  :{ex.Message}");
            throw;
        }
    }

    public async Task<IEnumerable<FlightListRessource>?> AllAsync()
    {
        try
        {
            Console.WriteLine(ApiUrl);
            var apiResponse = await _httpClient.GetStreamAsync($"{ApiUrl}api/Flight");

            var flightLists = await JsonSerializer.DeserializeAsync<IEnumerable<FlightListRessource>>(apiResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return flightLists;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error  :{ex.Message}");
            throw;
        }
    }

    public async Task<bool> DeleteAsync(string id)
    {
        try
        {
            var apiResponse = await _httpClient.DeleteAsync($"{ApiUrl}api/Flight/{id}");
            return apiResponse.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error  :{ex.Message}");
            throw;
        }
    }

    public async Task<FlightListRessource?> GetFlightAsync(string id)
    {
        try
        {
            var apiResponse = await _httpClient.GetStreamAsync($"{ApiUrl}api/Flight/{id}");
            var flight = await JsonSerializer.DeserializeAsync<FlightListRessource>(apiResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return flight;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error  :{ex.Message}");
            throw;
        }
    }

    public async Task<bool> UpdateAsync(UpdateFlightDto updateFlightDto)
    {
        try
        {
            var itemJson = new StringContent(JsonSerializer.Serialize(updateFlightDto), Encoding.UTF8, "application/json");
            var apiResponse = await _httpClient.PutAsync($"{ApiUrl}api/Flight", itemJson);
            return apiResponse.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error  :{ex.Message}");
            throw;
        }
    }
}
