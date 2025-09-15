using System.Text.Json.Serialization;

namespace Cinema.Application.Models;

public record SeatPlan
{
    [JsonPropertyName("auditorium")]
    public string? Auditorium { get; set; }

    [JsonPropertyName("filmTitle")]
    public string? FilmTitle { get; set; }

    [JsonPropertyName("startTime")]
    public TimeSpan StartTime { get; set; }

    [JsonPropertyName("seatRows")]
    public List<Seat>? Seats { get; set; }

    public class Seat
    {
        [JsonPropertyName("row")]
        public string? Row { get; set; }

        [JsonPropertyName("number")]
        public int Number { get; set; }

        [JsonPropertyName("status")]
        public Status Status { get; set; }
    }
}
