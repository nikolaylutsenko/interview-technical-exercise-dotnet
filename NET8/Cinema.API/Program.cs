using System.Text.Json;
using System.Text.Json.Serialization;
using Cinema.API;
using Cinema.Application.Interfaces;
using Cinema.Infrastructure.Clients;
using Cinema.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.Converters.Add(
        new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
    );
});

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(config =>
{
    config.DocumentName = "CinemaSeatServiceAPI";
    config.Title = "CinemaSeatServiceAPI v1";
    config.Version = "v1";
});

builder.Services.AddHttpClient();

builder.Services.AddScoped<ISeatMapService, SeatMapService>();
builder.Services.AddScoped<ISeatMapClient, SeatMapClient>();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.Logger.LogInformation("The app started");

CinemaSeatsEndpoints.Map(app);

app.Run();
