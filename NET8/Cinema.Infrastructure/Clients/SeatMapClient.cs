namespace Cinema.Infrastructure.Clients;

using System.Net.Http.Json;
using System.Text.Json;
using Application.Interfaces;
using Clients.Models;
using Domain.Models;
using Mappers;

public class SeatMapClient : ISeatMapClient
{
    private readonly IHttpClientFactory _httpClientFactory;

    public SeatMapClient(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<List<SeatPlan>> GetSeatPlans()
    {
        var httpClient = _httpClientFactory.CreateClient();
        var url =
            "https://raw.githubusercontent.com/DataArtInc/interview-technical-exercise/main/seatmap-example.json"; //TODO: move to secrets

        var options = new JsonSerializerOptions { AllowTrailingCommas = true };

        var response = await httpClient.GetFromJsonAsync<SeatMapApiModel[]>(url, options);
        if (response == null)
            throw new HttpRequestException($"Request to '{url}' failed or returned no content");

        var seatPlan = response.Select(SeatMapMapper.ToDomain).ToList();

        return seatPlan;
    }
}
