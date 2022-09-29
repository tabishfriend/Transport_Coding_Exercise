using Transport.Core.Interfaces;
using Transport.Models.Enumerations;

namespace Transport.Core;

public  class StartupService
{
    private readonly IOrderService _orderService;
    private readonly IPrintService _printService;
    public StartupService(IOrderService orderService,IPrintService printService)
    { 
        _orderService = orderService;
        _printService = printService;
    }

    public void PrintSchedule()
    {
        var schService = new FlightScheduleService()
                              .NumberOfDays(3)
                              .FlightFrom(Location.YUL)
                              .FlightTo(Location.YYZ)
                              .FlightTo(Location.YYC)
                              .FlightTo(Location.YVR);
        var report = schService.GetReportData();
        _printService.Print(report);
    }


    public void PrintOrderSchedule()
    {   
        var data = _orderService.Get();
        var ordSchService = new FlightOrderScheduleService()
                             .Orders(data)
                             .MaximumBoxes(20)
                             .FlightFrom(Location.YUL)
                             .FlightTo(Location.YYZ)
                             .FlightTo(Location.YYC)
                             .FlightTo(Location.YVR);
        var report = ordSchService.GetReportData();
        _printService.Print(report);

    }
}
