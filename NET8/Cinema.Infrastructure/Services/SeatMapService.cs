namespace Cinema.Infrastructure.Services;

using Application.DTOs;
using Application.Interfaces;
using Microsoft.Extensions.Caching.Memory;

public class SeatMapService : ISeatMapService
{
    private readonly ISeatMapClient _seatMap;

    public SeatMapService(ISeatMapClient seatMap)
    {
        _seatMap = seatMap;
    }

    public async Task<SeatAvailabilityApiModel> CheckSeatAvailability(
        string auditorium,
        string filmTitle,
        string seatRowNumber
    )
    {
        var seatPlans = await _seatMap.GetSeatPlans() ?? throw new InvalidDataException();
        var seatPlan =
            seatPlans.FirstOrDefault(sp =>
                sp.Auditorium.Equals(auditorium, StringComparison.OrdinalIgnoreCase)
                && sp.FilmTitle.Equals(filmTitle, StringComparison.OrdinalIgnoreCase)
            ) ?? throw new KeyNotFoundException("Seat plan not found");

        return new SeatAvailabilityApiModel { Available = seatPlan.IsSeatAvailable(seatRowNumber) };
    }

    public async Task<List<SeatPlanApiModel>> GetSeatPlans()
    {
        var seatPlans = await _seatMap.GetSeatPlans() ?? throw new InvalidDataException();

        return seatPlans.Select(ToApiModel).ToList();
    }

    private SeatPlanApiModel ToApiModel(Domain.Models.SeatPlan seatPlan)
    {
        return new SeatPlanApiModel
        {
            Auditorium = seatPlan.Auditorium,
            FilmTitle = seatPlan.FilmTitle,
            StartTime = seatPlan.StartTime.ToString("hh:mm"),
            Seats = seatPlan
                .Seats.Select(seat => new Seat
                {
                    Row = seat.Row,
                    Number = seat.Number,
                    Status = seat.Status,
                })
                .ToList(),
        };
    }
}
