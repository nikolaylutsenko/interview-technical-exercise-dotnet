using Cinema.Application.DTOs;

namespace Cinema.Application.Interfaces;

public interface ISeatMapService
{
    Task<List<SeatPlanApiModel>> GetSeatPlans();
    Task<SeatAvailabilityApiModel> CheckSeatAvailability(
        string auditorium,
        string filmTitle,
        string seatRowNumber
    );
}
