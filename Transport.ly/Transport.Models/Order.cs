using Newtonsoft.Json;
using Transport.Models.Enumerations;

namespace Transport.Models;
 
    public struct Order
    {
        public string  Name { get; set; }
        public string  OrderNumber { get { return  Name.Replace("order-", String.Empty); }   }
        public Location Destination { get; set; }
    }