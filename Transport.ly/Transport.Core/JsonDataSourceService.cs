using Newtonsoft.Json;
using Transport.Core.Interfaces;
using Transport.Models;
using Transport.Models.Enumerations;

namespace Transport.Core;

public class JsonDataSourceService : IDataSourceService
{
    private const string OrderSourceFileName = "coding-assigment-orders.json";
    public T Get<T>(DataSourceType type)
    {
        var jsonData = ReadFile(OrderSourceFileName);

        if (string.IsNullOrEmpty(jsonData))
            throw new Exception("Json data file is empty");


        dynamic? data = JsonConvert.DeserializeObject(jsonData);
        if(data==null)
            throw new Exception("Invalid Json data");

        switch (type)
        {
            case DataSourceType.Orders:
                return (T)GetOrders(data);
               
            default:
                throw new Exception("Json data type not configured");

        }           
        
    }

    private object GetOrders(dynamic orders)
    {
        var result = new List<Order>();
        var locationTyoe = typeof(Location);
        foreach (var order in orders)
        {
            var obj = new Order() { Name = order.Name };
            foreach (var attributes in order)
            {
                var dest = attributes.destination?.Value;
                if (dest != null)
                {
                    obj.Destination = (Location) Enum.Parse(locationTyoe, dest) ;
                }
            }
            result.Add(obj);
        }

        return result;
    }

    private string ReadFile(string fileName)
    {
        return File.ReadAllText($"json/{fileName}");
    }
}
