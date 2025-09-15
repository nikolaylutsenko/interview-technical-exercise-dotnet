using Cinema.Domain.Models;
using Cinema.Infrastructure.Clients;

namespace Cinema.Infrastructure.Services;

public class SeatMapService : ISeatMapService
{
    private readonly ISeatMapClient _seatMap;

    public SeatMapService(ISeatMapClient seatMap)
    {
        _seatMap = seatMap;
    }

    public Task<bool> CheckSeatAvailability(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<SeatPlan> GetSeatPlan()
    {
        var seatPlan = await _seatMap.GetSeatMap();

        return null;
    }
}
