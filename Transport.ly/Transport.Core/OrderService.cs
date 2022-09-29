using Transport.Core.Interfaces;
using Transport.Models;
using Transport.Models.Enumerations;

namespace Transport.Core;

public class OrderService : IOrderService
{
    private readonly IDataSourceService _dataService;
    public OrderService(IDataSourceService dataService)
    {
        _dataService = dataService;
    }

    public List<Order> Get()
    {
        return  _dataService.Get<List<Order>>(Transport.Models.Enumerations.DataSourceType.Orders);

    }

    public void GetReportData(int numberOfBoxes,Location from,List<Location> to)
    { 


    }
}
