// namespace Cinema.Infrastructure.Mappers;

// public class SeatMapMapper
// {
//     public SeatPlanApiModel ToApiModel(SeatMap seatMap)
//     {

//         return new SeatPlanApiModel
//         {
//             Auditorium = seatMap.Auditorium,
//             filmTitle = seatMap.FilmTitle,
//             StartTime = DateTimeOffset.FromUnixTimeSeconds(long.Parse(seatMap.StartTime)).TimeOfDay,
//             Seats = Calculate(seatMap.SeatRows)
//         }
//     }

//     public List<Seat> Calculate(List<Row> seatRows)
//     {
//         var seats = new List<Seat>();

//         foreach (var row in seatRows)
//         {
//             var rowSeats = row.SeatAvailability.ToCharArray();
//             for (int i = 0; i < rowSeats.Length; i++)
//             {
//                 var seat = new Seat { Row = row.Index, Number = i, Status = ToStatus(rowSeats[i]) };
//                 seats.Add(seat);
//             }
//         }

//         return seats;

//     }

//     private Status ToStatus(char statusChar)
//     {
//         if (statusChar == '0')
//             return Status.Available;
//         else if (statusChar == '1')
//             return Status.Booked;
//         else
//             throw new ArgumentOutOfRangeException();
//     }
