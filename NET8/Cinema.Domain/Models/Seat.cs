namespace Cinema.Domain.Models;

public class Seat
{
    public required string Row { get; set; }
    public required int Number { get; set; }
    public required Status Status { get; set; }
}
