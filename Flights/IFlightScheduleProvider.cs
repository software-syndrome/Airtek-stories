
namespace AirtekStories.Flights;
interface IFlighScheduleProvider
{
    IEnumerable<FlightSchedule> GetFlightSchedules();
}