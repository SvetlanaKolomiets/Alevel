using Collection.Entities;

namespace Collection.Repositories.Abstractions
{
	public interface IOrderRepository
	{
        Guid AddOrder(OrderEntity order);
        List<OrderEntity> GetOrders();
    }
}

