using Collection.Models;

namespace Collection.Services.Abstractions
{
	public interface IOrderService
	{
		Guid AddOrder(Order order);
		List<Order> GetOrders();
        List<Order> GetOrders(bool isDesc);
		List<Order> GetOrdersWithEmergency(bool isDesc);
    }
}

