namespace Cinema.API;

using Application.Interfaces;

public static class CinemaSeatsEndpoints
{
    public static void Map(WebApplication app)
    {
        var cinemaSeats = app.MapGroup("/cinema/seats");

        cinemaSeats.MapGet(
            "/plan",
            async (ISeatMapService seatMapService) => await seatMapService.GetSeatPlans()
        );

        cinemaSeats.MapGet(
            "/check/{id}",
            async (string id, ISeatMapService seatMapService) =>
                await seatMapService.CheckSeatAvailability(id)
        );
    }
}
