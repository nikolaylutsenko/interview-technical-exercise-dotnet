namespace Cinema.Infrastructure.Clients.Models;

using System.Text.Json.Serialization;

public class SeatMap
{
    [JsonPropertyName("auditorium")]
    public string? Auditorium { get; set; }

    [JsonPropertyName("filmTitle")]
    public string? FilmTitle { get; set; }

    [JsonPropertyName("startTime")]
    public string? StartTime { get; set; }

    [JsonPropertyName("seatRows")]
    public List<Row>? SeatRows { get; set; }

    public class Row
    {
        [JsonPropertyName("index")]
        public string? Index { get; set; }

        [JsonPropertyName("seatAvailability")]
        public string? SeatAvailability { get; set; }
    }
}
