using Cinema.Domain.Models;

namespace Cinema.Infrastructure.Services;

public interface ISeatMapService
{
    Task<SeatPlan> GetSeatPlan();
    Task<bool> CheckSeatAvailability(string id);
}
