// User Story 1: As an inventory management user, I can load a flight schedule similar to the one listed in the Scenario above. 
// For this story you do not yet need to load the orders. I can also list out the loaded flight schedule on the console.
using AirtekStories.Flights;
using AirtekStories.Orders;
using AirtekStories.Arrangement;
using System.Linq;

IFlighScheduleProvider schedulesProvider = new PredefinedScheduleProvider();

var schedulesOrderedByFlightId = schedulesProvider.GetFlightSchedules().OrderBy(schedule => schedule.FlightId);

Console.WriteLine("User Story 1");
foreach (var flight in schedulesOrderedByFlightId)
{
    Console.WriteLine($"Flight: {flight.FlightId}, departure: {flight.DepartureCityCode}, arrival: {flight.ArrivalCityCode}, day: {flight.DepartureDay}");
}


Console.WriteLine("User Story 2");
var ordersProvider = new JsonOrderProvider();
var flightSchedules = schedulesProvider.GetFlightSchedules();
var shippings = ShippingArranger.Arrange(ordersProvider.GetOrders(), flightSchedules);

foreach (var shipping in shippings)
{
    if (shipping.FlightId == null)
    {
        Console.WriteLine($"order: {shipping.OrderId}, flightNumber: not scheduled");
    }
    else
    {
        var flightDetails = flightSchedules.FirstOrDefault(flight => flight.FlightId == shipping.FlightId);
        Console.WriteLine(String.Format("order: {0}, flightNumber: {1}, departure: {2}, arrival: {3}, day: {4}",
        shipping.OrderId,
        shipping.FlightId,
        flightDetails.DepartureCityCode,
        flightDetails.ArrivalCityCode,
        flightDetails.DepartureDay));
    }
}
Console.ReadLine();
