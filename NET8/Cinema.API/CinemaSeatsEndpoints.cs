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
            "/check/{auditorium}/{filmTitle}/{seatRowNumber}",
            async (
                string auditorium,
                string filmTitle,
                string seatRowNumber,
                ISeatMapService seatMapService
            ) => await seatMapService.CheckSeatAvailability(auditorium, filmTitle, seatRowNumber)
        );
    }
}
