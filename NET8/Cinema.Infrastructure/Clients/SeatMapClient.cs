using System.Net.Http.Json;
using Cinema.Infrastructure.Clients.Models;

namespace Cinema.Infrastructure.Clients;

public class SeatMapClient : ISeatMapClient
{
    private readonly HttpClient _httpClient;

    public SeatMapClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<SeatMap?> GetSeatMap()
    {
        return await _httpClient.GetFromJsonAsync<SeatMap>(
            "https://raw.githubusercontent.com/DataArtInc/interview-technical-exercise/main/seatmap-example.json"
        );
    }
}
