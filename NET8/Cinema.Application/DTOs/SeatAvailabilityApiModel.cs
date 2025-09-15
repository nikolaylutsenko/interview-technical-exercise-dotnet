using System.Text.Json.Serialization;

namespace Cinema.Application.DTOs;

public record SeatAvailabilityApiModel
{
    [JsonPropertyName("available")]
    public bool Available { get; set; }
};
