using Microsoft.AspNetCore.Mvc;

namespace Homework31.Controllers;

[ApiController]
[Route(("[controller]"))]
public class ProductController
{
    private static readonly string[] Products = new[]
    {
        "Jeans", "T-short", "Short", "Pants", "Hat",
        "Blouse", "Dress", "Sweatshirt", "Boots", "Sneakers"
    };
    
    [HttpGet]
    public IEnumerable<Products> Get()
    {
        List<Products> products = new List<Products>();
    
        for (int i = 0; i < Products.Length; i++)
        {
            products.Add(new Products
            {
                Id = Guid.NewGuid(),
                Name = Products[i]
            });
        }
    
        return products;
    }
}