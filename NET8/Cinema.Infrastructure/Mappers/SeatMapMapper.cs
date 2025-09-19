namespace Cinema.Infrastructure.Mappers;

using Clients.Models;
using Domain.Models;

public static class SeatMapMapper
{
    public static SeatPlan ToDomain(SeatMapApiModel seatMap)
    {
        return new SeatPlan
        {
            Auditorium = seatMap.Auditorium,
            FilmTitle = seatMap.FilmTitle,
            StartTime = DateTimeOffset.FromUnixTimeSeconds(long.Parse(seatMap.StartTime)),
            Seats = Calculate(seatMap.SeatRows),
        };
    }

    private static List<Seat> Calculate(Dictionary<string, string> seatRows)
    {
        var seats = new List<Seat>();

        foreach (var row in seatRows)
        {
            var rowSeats = row.Value.ToCharArray();
            for (int i = 1; i < rowSeats.Length; i++)
            {
                var seat = new Seat
                {
                    Row = row.Key,
                    Number = i,
                    Status = ToStatus(rowSeats[i]),
                };
                seats.Add(seat);
            }
        }

        return seats;
    }

    private static Status ToStatus(char statusChar)
    {
        if (statusChar == '0')
            return Status.Available;
        else if (statusChar == '1')
            return Status.Booked;
        else
            throw new ArgumentOutOfRangeException();
    }
}
