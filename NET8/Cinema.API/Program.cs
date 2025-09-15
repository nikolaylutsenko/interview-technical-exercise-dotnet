using Cinema.API;
using Cinema.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(config =>
{
    config.DocumentName = "CinemaSeatServiceAPI";
    config.Title = "CinemaSeatServiceAPI v1";
    config.Version = "v1";
});

builder.Services.AddScoped<ISeatMapService, SeatMapService>();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.Logger.LogInformation("The app started");

CinemaSeatsEndpoints.Map(app);

app.Run();
