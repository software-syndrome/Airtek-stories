using AirtekStories.Flights;
using AirtekStories.Orders;
using AirtekStories.Arrangement;

namespace AirtekStories.Arrangement;

public static class ShippingArranger
{
    public  static ArrangedShipping[] Arrange(IEnumerable<Order> orders, IEnumerable<FlightSchedule> flights)
    {
        var orderedFlights = flights.OrderBy(flight => flight.DepartureDay);
        var shippings = new List<ArrangedShipping>();
        var flightsGroupByArrivalCity = flights.OrderBy(flight => flight.DepartureDay)
                                            .Select(flight => new FlightCapacityReference(flight, flight.OrderCapacity))
                                            .GroupBy(flightCapacityReference => flightCapacityReference.FlightSchedule.ArrivalCityCode).ToArray();
        foreach (var order in orders)
        {
            var properArrivalGroup = Array.Find(flightsGroupByArrivalCity, g => g.Key == order.ArrivalCityCode);
            var flightCapacityReference = properArrivalGroup?.Where(g => g.RemainingCapacity > 0).FirstOrDefault();
            uint? flightId = null;
            if (flightCapacityReference != null)
            {
                flightCapacityReference.ReduceCapacity();
                flightId = flightCapacityReference.FlightSchedule.FlightId;
            }

            var newShipping = new ArrangedShipping()
            {
                OrderId = order.OrderId,
                FlightId = flightId
            };

            shippings.Add(newShipping);
        }
        return shippings.ToArray();
    }

}

internal class FlightCapacityReference
{
    private uint remainingCapacity;
    public FlightCapacityReference(FlightSchedule flight, uint initialCapacity)
    {
        remainingCapacity = initialCapacity;
        FlightSchedule = flight;
    }
    public FlightSchedule FlightSchedule { get; set; }

    public uint RemainingCapacity => remainingCapacity;

    public bool ReduceCapacity(uint amount = 1)
    {
        if (remainingCapacity > 0)
        {
            remainingCapacity--;
            return true;
        }

        return false;
    }

}