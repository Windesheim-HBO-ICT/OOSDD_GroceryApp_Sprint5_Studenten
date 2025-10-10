using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace Grocery.Core.Data.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly List<ProductCategory> productCategories = new()
        {
            new ProductCategory(1, 1, 1), // Melk - Zuivel
            new ProductCategory(2, 2, 1), // Kaas - Zuivel
            new ProductCategory(3, 3, 2), // Brood - Bakkerij
            new ProductCategory(4, 4, 3)  // Cornflakes - Ontbijtgranen
        };

        public List<ProductCategory> GetAll() => productCategories;
        public ProductCategory? Get(int id) => productCategories.FirstOrDefault(pc => pc.Id == id);
        public ProductCategory Add(ProductCategory productCategory) { productCategories.Add(productCategory); return productCategory; }
        public ProductCategory? Delete(ProductCategory productCategory) { productCategories.Remove(productCategory); return productCategory; }
        public ProductCategory? Update(ProductCategory productCategory)
        {
            var pc = productCategories.FirstOrDefault(p => p.Id == productCategory.Id);
            if (pc == null) return null;
            pc.ProductId = productCategory.ProductId;
            pc.CategoryId = productCategory.CategoryId;
            return pc;
        }
    }
}
