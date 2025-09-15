namespace Cinema.Infrastructure.Services;

using Application.DTOs;
using Application.Interfaces;
using Application.Models;
using Clients.Models;

public class SeatMapService : ISeatMapService
{
    private readonly ISeatMapClient _seatMap;

    public SeatMapService(ISeatMapClient seatMap)
    {
        _seatMap = seatMap;
    }

    public Task<SeatAvailabilityApiModel> CheckSeatAvailability(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<SeatPlanApiModel>> GetSeatPlans()
    {
        var seatPlans =
            await _seatMap.GetSeatMap<SeatMapApiModel[]>() ?? throw new InvalidDataException();

        return seatPlans.Select(ToApiModel).ToList();
    }

    private SeatPlanApiModel ToApiModel(SeatMapApiModel seatMap)
    {
        return new SeatPlanApiModel
        {
            Auditorium = seatMap.Auditorium,
            FilmTitle = seatMap.FilmTitle,
            StartTime = DateTimeOffset
                .FromUnixTimeSeconds(long.Parse(seatMap.StartTime))
                .ToLocalTime()
                .ToString("hh:mm"),
            Seats = Calculate(seatMap.SeatRows),
        };
    }

    private List<Seat> Calculate(Dictionary<string, string> seatRows)
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

    private Status ToStatus(char statusChar)
    {
        if (statusChar == '0')
            return Status.Available;
        else if (statusChar == '1')
            return Status.Booked;
        else
            throw new ArgumentOutOfRangeException();
    }
}
