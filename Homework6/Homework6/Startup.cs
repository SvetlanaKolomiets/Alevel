using Homework6.Repositories;
using Homework6.Services;
namespace Homework6
{
	public class Startup
	{
		private ShopService _shopService;
		public Startup()
		{
            var productService = new ProductService(new ProductRepository());
            var orderService = new OrderService(productService, new BillRepository());
            _shopService = new ShopService(orderService, productService);
        }

		public void Run()
        {
			_shopService.GetBill();
		}
    }
}

