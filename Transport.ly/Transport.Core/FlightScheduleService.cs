using Transport.Models.Enumerations;

namespace Transport.Core;

internal class FlightScheduleService
{
    private int _days;
    private List<Location> _flightFrom;
    private List<Location> _flightTo;

    public FlightScheduleService()
    {
        _flightFrom = new List<Location>();
        _flightTo = new List<Location>();
    }

    public FlightScheduleService NumberOfDays(int a)
    {
        _days = a;
        return this;
     }

    public FlightScheduleService FlightFrom(Location from)
    {
        _flightFrom.Add(from);
        return this;
    }

    public FlightScheduleService FlightTo(Location to)
    {
        _flightTo.Add(to);
        return this;
    }   

    public List<string> GetReportData()
    {
        var data = new List<string>();
        data.Add("*********** USER STORY #1 ***********");

        int flight = 1;

        for (int day = 1; day <= _days; day++)
        {
           foreach (var from in _flightFrom)
            {
                foreach (var to in _flightTo)
                {
                    data.Add($"Flight: {flight++}, departure: {from.ToString()}, arrival: {to.ToString()}, day: {day}");
                }
                ;
            }        
        }
        data.Add("");
        return data;
    }
}
