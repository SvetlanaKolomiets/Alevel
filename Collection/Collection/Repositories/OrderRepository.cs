using Collection.Entities;
using Collection.Repositories.Abstractions;

namespace Collection.Repositories
{
	public class OrderRepository : IOrderRepository
    {
        private List<OrderEntity> orders = new List<OrderEntity>();

        public OrderRepository()
		{
            orders = new List<OrderEntity>()
            {
                new OrderEntity()
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.UtcNow,
                    IsEmergency = true
                },
                new OrderEntity()
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.UtcNow,
                    IsEmergency = false
                },
                new OrderEntity()
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.UtcNow.AddHours(1),
                    IsEmergency = true
                },
                new OrderEntity()
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.Now.AddHours(1),
                    IsEmergency = true
                }
            };
		}

        public Guid AddOrder(OrderEntity order)
        {
            order.Id = Guid.NewGuid();

            orders.Add(order);

            return order.Id;
        }

        public List<OrderEntity> GetOrders()
        {
            return orders;
        }
    }
}

