
namespace AirtekStories.Flights;
public class FlightSchedule
{
    public uint FlightId { get; set; }
    public string DepartureCityCode { get; set; }
    public string ArrivalCityCode { get; set; }
    public uint DepartureDay { get; set; }
    public uint OrderCapacity = 20;
}