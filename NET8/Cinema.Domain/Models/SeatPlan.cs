namespace Cinema.Domain.Models;

public record SeatPlan
{
    public required string Auditorium { get; set; }
    public required string FilmTitle { get; set; }
    public required TimeSpan StartTime { get; set; }
    public required List<Seat> Seats { get; set; }
}
