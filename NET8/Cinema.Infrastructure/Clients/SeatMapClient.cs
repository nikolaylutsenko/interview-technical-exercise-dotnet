namespace Cinema.Infrastructure.Clients;

using System.Net.Http.Json;
using System.Text.Json;
using Application.Interfaces;
using Clients.Models;
using Domain.Models;
using Mappers;
using Microsoft.Extensions.Caching.Memory;

public class SeatMapClient : ISeatMapClient
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IMemoryCache _cache;

    public SeatMapClient(IHttpClientFactory httpClientFactory, IMemoryCache cache)
    {
        _httpClientFactory = httpClientFactory;
        _cache = cache;
    }

    public async Task<List<SeatPlan>> GetSeatPlans()
    {
        var key = "seatPlans";
        SeatMapApiModel[]? response = null;

        _cache.TryGetValue(key, out SeatMapApiModel[]? cached);
        if (cached is null)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var url =
                "https://raw.githubusercontent.com/DataArtInc/interview-technical-exercise/main/seatmap-example.json"; //TODO: move to secrets

            var options = new JsonSerializerOptions { AllowTrailingCommas = true };

            response = await httpClient.GetFromJsonAsync<SeatMapApiModel[]>(url, options);
            if (response == null)
                throw new HttpRequestException($"Request to '{url}' failed or returned no content");

            _cache.Set(
                key,
                response,
                new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
                    SlidingExpiration = TimeSpan.FromMinutes(2),
                    Size = 1,
                }
            );
        }
        else
        {
            response = cached;
        }

        var seatPlan = response.Select(SeatMapMapper.ToDomain).ToList();

        return seatPlan;
    }
}
