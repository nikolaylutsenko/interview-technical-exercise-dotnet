namespace Cinema.API;

using Application.Interfaces;

public static class CinemaSeatsEndpoints
{
    public static void Map(WebApplication app)
    {
        var cinemaSeats = app.MapGroup("/cinema/seats");

        cinemaSeats.MapGet(
            "/plan",
            async (ISeatMapService seatMapService, ILogger<Program> logger) =>
            {
                var result = await seatMapService.GetSeatPlans();

                return TypedResults.Ok(result);
            }
        );

        cinemaSeats.MapGet(
            "/check/{auditorium}/{filmTitle}/{seatRowNumber}",
            async (
                string auditorium,
                string filmTitle,
                string seatRowNumber,
                ISeatMapService seatMapService
            ) =>
            {
                var result = await seatMapService.CheckSeatAvailability(
                    auditorium,
                    filmTitle,
                    seatRowNumber
                );

                return TypedResults.Ok(result);
            }
        );
    }
}
