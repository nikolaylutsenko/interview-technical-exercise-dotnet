namespace Cinema.Application.Interfaces;

public interface ISeatMapClient
{
    Task<T?> GetSeatMap<T>();
}
