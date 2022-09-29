using Transport.Models;
using Transport.Models.Enumerations;

namespace Transport.Core;

internal class FlightOrderScheduleService
{
    private int _maxBoxes;
    private List<Location> _flightFrom;
    private List<Location> _flightTo;
    private List<Order> _orders;

    public FlightOrderScheduleService()
    {
        _flightFrom = new List<Location>();
        _flightTo = new List<Location>();
        _orders = new List<Order>();
    }

    public FlightOrderScheduleService MaximumBoxes(int boxes)
    {
        _maxBoxes = boxes;
        return this;
    }

    public FlightOrderScheduleService FlightFrom(Location from)
    {
        _flightFrom.Add(from);
        return this;
    }

    public FlightOrderScheduleService FlightTo(Location to)
    {
        _flightTo.Add(to);
        return this;
    }

    public FlightOrderScheduleService Orders(List<Order> orders)
    {
        _orders = orders;
        return this;
    }

    public List<string> GetReportData()
    {
        var data = new List<string>();
        data.Add("*********** USER STORY #2 ***********");

        var maxBoxTracking = InitBoxTracking();
        int toCount = _flightTo.Count;

        foreach (var from in _flightFrom)
        {
            foreach (var order in _orders)
            {
                var flight = maxBoxTracking.FirstOrDefault(i => i.Flight == order.Destination);
                if (flight != null)
                {
                    flight.BoxCounter++;
                    data.Add($"order: {order.Name}, flightNumber: {flight.FlightNumber}, departure:" +
                        $" {from}, arrival: {order.Destination}, day: {flight.Day}");

                    if (flight.BoxCounter >= _maxBoxes)
                    {
                        flight.NextDay(toCount);
                    }
                }
                else
                {
                    data.Add($"order: {order.Name}, flightNumber: not scheduled");
                }
            }
        }

        return data;
    }

    private List<BoxTracking> InitBoxTracking()
    {
        // Day -  Flight number - box count 
        var tracking = new List<BoxTracking>();
        int flightNumber = 1;
        foreach (var destination in _flightTo)
        {
            tracking.Add(new BoxTracking { Flight = destination, BoxCounter = 0, Day = 1, FlightNumber = flightNumber++ });
        }

        return tracking;

    }

    internal class BoxTracking
    {
        public int Day { get; set; }
        public int FlightNumber { get; set; }
        public Location Flight { get; set; }
        public int BoxCounter { get; set; }

        public void NextDay(int totalFlights)
        {
            BoxCounter = 0;
            Day++;
            FlightNumber += totalFlights;
        }
    }
}
