using Homework6.Models;
using Homework6.Repositories;

namespace Homework6.Services
{
	public class OrderService
	{
		private ProductService _productService;
		private BillRepository _billRepository;
		private double _totalPrice = 0;
        private Product[] _basket;
        public OrderService(ProductService productService, BillRepository billRepository)
		{
			_productService = productService;
			_billRepository = billRepository;
			_basket = _productService.GetBasket();

        }

		public double TotalPrice()
		{
            if (_basket != null)
            {
                foreach (var product in _basket)
                {

                    {
                        _totalPrice += product.ProductPrice;
                    }
                }
                return _totalPrice;
            }
            return 0.0;
        }

		public string DisplayAllProducts()
		{
            if (_basket != null && _basket.Length > 0)
            {
                string products = "";
                foreach (var product in _basket)
                {
                    products += product.ProductName + Environment.NewLine;
                }
                return products;
            }
            return null;
        }

		public string AddBill(string product, double price)
		{
            var id = _billRepository.AddBill(product, price);
            return id;
        }

		public void GetBill(string id)
		{
			var billEntity = _billRepository.GetBill(id);
            if (billEntity != null)
            {
                var bill = new Bill()
                {
                    Id = billEntity.Id,
                    ShopName = billEntity.ShopName,
                    Date = billEntity.Date,
                    Products = this.DisplayAllProducts(),
                    TotalPrice = _totalPrice
                };
                
                Console.WriteLine($"You made an order! Your order id is: {bill.Id}{Environment.NewLine}" +
                          $"{bill.ShopName}{Environment.NewLine}{bill.Date}{Environment.NewLine}" +
                          $"Products in your basket:{Environment.NewLine}{billEntity.Products}{Environment.NewLine}" +
                          $"Total price is: {bill.TotalPrice}");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"Not founded bill with this id = {id}");
            }
        }
    }

}


