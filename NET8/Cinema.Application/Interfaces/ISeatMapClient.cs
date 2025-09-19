namespace Cinema.Application.Interfaces;

using Domain.Models;

public interface ISeatMapClient
{
    Task<List<SeatPlan>> GetSeatPlans();
}
