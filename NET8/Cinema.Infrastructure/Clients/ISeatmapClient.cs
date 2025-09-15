using Cinema.Infrastructure.Clients.Models;

namespace Cinema.Infrastructure.Clients;

public interface ISeatMapClient
{
    Task<SeatMap?> GetSeatMap();
}
