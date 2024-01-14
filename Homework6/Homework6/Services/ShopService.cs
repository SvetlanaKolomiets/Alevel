namespace Homework6.Services
{
	public class ShopService
	{
		private OrderService _orderService;
		private ProductService _productService;
        public ShopService(OrderService orderService, ProductService productService)
		{
			_orderService = orderService;
			_productService = productService;

        }


        public void GetBasket()
		{
			_productService.GetBasket();
        }

        public void GetBill()
		{
            var totalPrice = _orderService.TotalPrice();
            var products = _orderService.DisplayAllProducts();
            var billId = _orderService.AddBill(products, totalPrice);

			_orderService.GetBill(billId);
        }
	}
}

