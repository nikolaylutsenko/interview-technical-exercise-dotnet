namespace Cinema.Application.DTOs;

using System.Text.Json.Serialization;
using Domain.Models;

public record SeatPlanApiModel
{
    [JsonPropertyName("auditorium")]
    public required string Auditorium { get; set; }

    [JsonPropertyName("filmTitle")]
    public required string FilmTitle { get; set; }

    [JsonPropertyName("startTime")]
    public required string StartTime { get; set; }

    [JsonPropertyName("seatRows")]
    public required List<Seat> Seats { get; set; }
}

public class Seat
{
    [JsonPropertyName("row")]
    public required string Row { get; set; }

    [JsonPropertyName("number")]
    public required int Number { get; set; }

    [JsonPropertyName("status")]
    public required Status Status { get; set; }
}
