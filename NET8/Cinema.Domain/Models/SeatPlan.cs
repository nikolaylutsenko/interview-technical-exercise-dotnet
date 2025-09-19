namespace Cinema.Domain.Models;

public record SeatPlan
{
    public required string Auditorium { get; set; }
    public required string FilmTitle { get; set; }
    public required DateTimeOffset StartTime { get; set; }
    public required List<Seat> Seats { get; set; }

    public bool IsSeatAvailable(string seatRowNumber)
    {
        var splitSeatRowNumber = seatRowNumber.ToCharArray();
        var row = splitSeatRowNumber[0].ToString();
        var number = int.Parse(new string(splitSeatRowNumber[1..]));

        var seat = Seats.FirstOrDefault(s => s.Row == row && s.Number == number);
        if (seat == null)
            throw new ArgumentOutOfRangeException(nameof(seatRowNumber), "Seat does not exist.");

        return seat.Status == Status.Available;
    }
}
