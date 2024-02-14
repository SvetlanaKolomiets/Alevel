using Collection.Entities;
using Collection.Extensions;
using Collection.Models;
using Collection.Repositories.Abstractions;
using Collection.Services.Abstractions;

namespace Collection.Services
{
	public class OrderService : IOrderService
    {
		private readonly IOrderRepository _orderRepository;

		public OrderService(IOrderRepository orderRepository)
		{
			_orderRepository = orderRepository;
		}

		public Guid AddOrder(Order order)
		{
			var orderEntity = new OrderEntity()
			{
				CreatedAt = order.CreatedAt,
				IsEmergency = order.IsEmergency
			};

			var id = _orderRepository.AddOrder(orderEntity);

			return id;
		}

		public List<Order> GetOrders()
		{
			var orderEntities = _orderRepository.GetOrders();

			var orders = new List<Order>();
			
			foreach (var orderEntity in orderEntities)
			{
				orders.Add(new Order()
				{
					Id = orderEntity.Id,
					CreatedAt = orderEntity.CreatedAt,
					IsEmergency = orderEntity.IsEmergency
				});
			}

			orders = orders
				.OrderByDescending(x => x.IsEmergency)
				.ThenBy(x => x.CreatedAt)
				.ToList();

            return orders;
		}

		public List<Order> GetOrders(bool isDesc)
		{
			return (!isDesc)
				? GetOrders().SortByCreatedAt()
				: GetOrders();
        }

        public List<Order> GetOrdersWithEmergency(bool isDesc)
        {
			var orders = GetOrders();

			var emergencyOrder = orders
				.Where(x => x.IsEmergency)
				.ToList();

			orders.RemoveAll(item => emergencyOrder.Contains(item));

			emergencyOrder = emergencyOrder.SortByCreatedAt();
			orders = orders.SortByCreatedAt();

			emergencyOrder.AddRange(orders);

			return emergencyOrder;
        }
    }
}

