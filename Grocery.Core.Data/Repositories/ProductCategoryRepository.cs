using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Models;

namespace Grocery.Core.Data.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly List<ProductCategory> _productCategories = new()
        {
            new ProductCategory { Id = 1, ProductId = 1, CategoryId = 1 },
            new ProductCategory { Id = 2, ProductId = 2, CategoryId = 1 },
            new ProductCategory { Id = 3, ProductId = 3, CategoryId = 2 },
            new ProductCategory { Id = 4, ProductId = 4, CategoryId = 3 }
        };

        private readonly IProductRepository _productRepository;

        public ProductCategoryRepository(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<ProductCategory> GetAll() => _productCategories;

        public ProductCategory? GetById(int id) =>
            _productCategories.FirstOrDefault(pc => pc.Id == id);

        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
        {
            var productIds = _productCategories
                .Where(pc => pc.CategoryId == categoryId)
                .Select(pc => pc.ProductId)
                .ToList();

            return _productRepository
                .GetAll()
                .Where(p => productIds.Contains(p.Id));
        }
    }
}
