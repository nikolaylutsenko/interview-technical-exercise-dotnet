namespace Cinema.Infrastructure.Clients.Models;

using System.Text.Json.Serialization;

public class SeatMapApiModel
{
    [JsonPropertyName("auditorium")]
    public required string Auditorium { get; set; }

    [JsonPropertyName("filmTitle")]
    public required string FilmTitle { get; set; }

    [JsonPropertyName("startTime")]
    public required string StartTime { get; set; }

    [JsonPropertyName("seatRows")]
    public required Dictionary<string, string> SeatRows { get; set; }
}
