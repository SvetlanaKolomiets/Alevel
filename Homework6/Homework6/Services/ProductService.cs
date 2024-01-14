using Homework6.Models;
using Homework6.Repositories;

namespace Homework6.Services
{
	public class ProductService
	{
		private ProductRepository _productRepository;
        private Product[] _basket = new Product[0];
        private int _productInBacketCount = 0;
        public ProductService(ProductRepository product)
		{
            _productRepository = product;
		}

		public void AddToBasket(Product product)
		{
            _basket[_productInBacketCount] = product;
            _productInBacketCount++;
		}

		public void IsProductPresent()
		{
            Console.WriteLine($"Enter products names. Max 10 products. For exit type 'Quit' and press Enter:");

            for (int element = 0; element < 10; element++)
            {
                string input = Console.ReadLine().ToString();
                {
                    var productEntity = _productRepository.GetProducts(input);
                    
                    if (productEntity != null && input == productEntity.ProductName)
                    {
                        var product = new Product()
                        {
                            Id = productEntity.Id,
                            ProductName = productEntity.ProductName,
                            ProductPrice = productEntity.ProductPrice
                        };
                        Array.Resize(ref _basket, _basket.Length + 1);
                        this.AddToBasket(product);

                    }
                    else if (input.Equals("Quit", StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Try again");
                        element--;
                    }
                }
            }
        }

		public Product[] GetBasket()
		{

            this.IsProductPresent();
            if (_basket.Length == 0)
            {
                Console.WriteLine($"Your basket is empty");
                return null;
            }
			return _basket;
		}

	}
	}

