namespace FlightList.Client.BlazorWA.Models;

public class ApiSettings
{
    private readonly IConfiguration _configuration;

    public ApiSettings(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string ApiUrl => _configuration.GetSection("ApiSettings")["ApiUrl"] ?? "http://localhost:5250/";
}