namespace Cinema.Infrastructure.Clients;

using System.Net.Http.Json;
using System.Text.Json;
using Cinema.Application.Interfaces;

public class SeatMapClient : ISeatMapClient
{
    private readonly IHttpClientFactory _httpClientFactory;

    public SeatMapClient(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<T?> GetSeatMap<T>()
    {
        var httpClient = _httpClientFactory.CreateClient();
        var url =
            "https://raw.githubusercontent.com/DataArtInc/interview-technical-exercise/main/seatmap-example.json";

        var options = new JsonSerializerOptions { AllowTrailingCommas = true };

        var response = await httpClient.GetFromJsonAsync<T>(url, options);
        if (response == null)
            throw new HttpRequestException($"Request to '{url}' failed or returned no content");

        return response;
    }
}
