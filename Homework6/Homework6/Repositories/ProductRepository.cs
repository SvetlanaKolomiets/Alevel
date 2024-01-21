using Homework6.Entities;

namespace Homework6.Repositories
{
	public class ProductRepository
	{
        private ProductEntity[] _products = new ProductEntity[13];
		private int _productCount = 0;
		public ProductRepository()
		{
			GenerateProducts();
        }

        public void AddProduct(string id, string productName, double productPrice)
		{
			var product = new ProductEntity()
			{
				Id = id,
				ProductName = productName,
				ProductPrice = productPrice
			};

			_products[_productCount] = product;
			_productCount++;

		}

		public ProductEntity[] GenerateProducts()
        {
            string[] productNames = {"oranges", "milk", "avocado", "cucumber",
				"banana", "rice", "butter", "cheese", "eggs", "cake", "muffin", "coffee", "juice"};
            double[] productPrices = {1.15, 2.30, 5.50, 0.45, 2.00, 7.20, 4.40,
				5.10, 3.10, 9.85, 1.95, 15.50, 2.65};

            for (int element = 0; element < productNames.Length; element++)
            {
				AddProduct(Guid.NewGuid().ToString(), productNames[element], productPrices[element]);

            }

			return _products;
        }

        public ProductEntity GetProducts(string productName)
		{
            foreach (var product in _products)
            {
				if (product != null && product.ProductName == productName)
				{
					return product;
				}
			}

			return null;
		}
	}
}