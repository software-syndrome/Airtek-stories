
namespace AirTekSotires.Flights;
public class FlightSchedule
{
    public int FlightId { get; set; }
    public string DepartureCityCode { get; set; }
    public string ArrivalCityCode { get; set; }
    public uint DepartureDay { get; set; }
}