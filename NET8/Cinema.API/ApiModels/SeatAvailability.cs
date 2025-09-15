using System.Text.Json.Serialization;

namespace Cinema.API.ApiModels;

public record SeatAvailabilityApiModel
{
    [JsonPropertyName("available")]
    public bool Available { get; set; }
};

public record SeatPlanApiModel
{
    [JsonPropertyName("auditorium")]
    public string? Auditorium { get; set; }

    [JsonPropertyName("filmTitle")]
    public string? filmTitle { get; set; }

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

public enum Status
{
    Available = 100,
    Booked = 200,
}
