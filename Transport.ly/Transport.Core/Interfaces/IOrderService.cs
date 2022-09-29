using Transport.Models;

namespace Transport.Core.Interfaces;

public interface IOrderService
{
    List<Order> Get();
}
