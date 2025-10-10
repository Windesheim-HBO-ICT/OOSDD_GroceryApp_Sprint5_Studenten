using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Models;

namespace Grocery.Core.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products;

        public ProductRepository()
        {
            _products = new List<Product>
            {
                new Product(1, "Melk", 300, new DateOnly(2025, 9, 25)),
                new Product(2, "Kaas", 100, new DateOnly(2025, 9, 30)),
                new Product(3, "Brood", 400, new DateOnly(2025, 9, 12)),
                new Product(4, "Cornflakes", 0, new DateOnly(2025, 12, 31))
            };
        }

        public IEnumerable<Product> GetAll() => _products;

        public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);

        public Product Add(Product item)
        {
            _products.Add(item);
            return item;
        }

        public Product? Delete(Product item)
        {
            if (_products.Remove(item))
                return item;
            return null;
        }

        public Product? Update(Product item)
        {
            var product = _products.FirstOrDefault(p => p.Id == item.Id);
            if (product == null)
                return null;

            product.Stock = item.Stock;
            product.ShelfLife = item.ShelfLife;
            return product;
        }
    }
}
