using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Models;

namespace Grocery.Core.Data.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly List<ProductCategory> productCategories;
        public ProductCategoryRepository()
        {
            productCategories = [
                new ProductCategory(1, "MelkZuivel", 1, 1),
                new ProductCategory(2, "KaasZuivel", 2, 1),
                new ProductCategory(3, "BroodBekkerij", 3, 2),
                new ProductCategory(4, "CornflakesBekkerij", 4, 2)
            ];
        }
        public List<ProductCategory> GetAll()
        {
            return productCategories;
        }

        public ProductCategory? Get(int id)
        {
            return productCategories.FirstOrDefault(p => p.Id == id);
        }

        public ProductCategory Add(ProductCategory item)
        {
            productCategories.Add(item);
            return item;
        }

        public ProductCategory? Delete(ProductCategory item)
        {
            throw new NotImplementedException();
        }

        public ProductCategory? Update(ProductCategory item)
        {
            ProductCategory? product = productCategories.FirstOrDefault(p => p.Id == item.Id);
            if (product == null) return null;
            product.Id = item.Id;
            return product;
        }
    }
}
