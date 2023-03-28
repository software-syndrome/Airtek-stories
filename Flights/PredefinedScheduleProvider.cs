namespace AirtekStories.Flights;

public class PredefinedScheduleProvider : IFlighScheduleProvider
{
    public IEnumerable<FlightSchedule> GetFlightSchedules()
    {
        return new FlightSchedule[] {
            new FlightSchedule(){
                    FlightId = 1,
                    DepartureCityCode = "YUL",
                    ArrivalCityCode = "YYZ",
                    DepartureDay = 1
               },
            new FlightSchedule(){
                    FlightId = 2,
                    DepartureCityCode = "YUL",
                    ArrivalCityCode = "YYC",
                    DepartureDay = 1
                },
            new FlightSchedule(){
                    FlightId = 3,
                    DepartureCityCode = "YUL",
                    ArrivalCityCode = "YVR",
                    DepartureDay = 1
                },
            new FlightSchedule(){
                    FlightId = 4,
                    DepartureCityCode = "YUL",
                    ArrivalCityCode = "YYZ",
                    DepartureDay = 2
               },
            new FlightSchedule(){
                    FlightId = 5,
                    DepartureCityCode = "YUL",
                    ArrivalCityCode = "YYC",
                    DepartureDay = 2
                },
            new FlightSchedule(){
                    FlightId = 6,
                    DepartureCityCode = "YUL",
                    ArrivalCityCode = "YVR",
                    DepartureDay = 2
                }
        };
    }
}