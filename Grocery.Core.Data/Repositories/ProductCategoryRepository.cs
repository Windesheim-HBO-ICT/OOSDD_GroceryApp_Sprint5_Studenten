using Grocery.Core.Interfaces;
using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grocery.Core.Data.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly IProductRepository _productRepository;
        private readonly List<ProductCategory> _productCategories;

        public ProductCategoryRepository(IProductRepository productRepository)
        {
            _productRepository = productRepository;

         
            _productCategories = new List<ProductCategory>
            {
                new ProductCategory { Id = 1, ProductId = 1, CategoryId = 1 }, // Melk → Zuivel
                new ProductCategory { Id = 2, ProductId = 2, CategoryId = 1 }, // Kaas → Zuivel
                new ProductCategory { Id = 3, ProductId = 3, CategoryId = 2 }, // Brood → Bakkerij
                new ProductCategory { Id = 4, ProductId = 4, CategoryId = 3 }, // Cornflakes → Ontbijtgranen
            };
        }

        public Task<IEnumerable<ProductCategory>> GetByCategoryIdAsync(int categoryId)
        {
            var products = _productRepository.GetAll();

            var result = _productCategories
                .Where(pc => pc.CategoryId == categoryId)
                .Select(pc =>
                {
                    pc.Product = products.FirstOrDefault(p => p.Id == pc.ProductId);
                    return pc;
                })
                .Where(pc => pc.Product != null);

            return Task.FromResult(result.AsEnumerable());
        }

        public Task AddAsync(ProductCategory productCategory)
        {
            int newId = _productCategories.Any() ? _productCategories.Max(pc => pc.Id) + 1 : 1;
            productCategory.Id = newId;
            _productCategories.Add(productCategory);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            var existing = _productCategories.FirstOrDefault(pc => pc.Id == id);
            if (existing != null)
                _productCategories.Remove(existing);
            return Task.CompletedTask;
        }
    }
}