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
                new ProductCategory(1, 1, 1), // Melk -> Zuivel
                new ProductCategory(2, 1, 4), // Melk -> Verse producten
                new ProductCategory(3, 2, 1), // Kaas -> Zuivel
                new ProductCategory(4, 2, 4), // Kaas -> Verse producten
                new ProductCategory(5, 3, 2), // Brood -> Brood en graanproducten
                new ProductCategory(6, 3, 4), // Brood -> Verse producten
                new ProductCategory(7, 4, 2), // Cornflakes -> Brood en graanproducten
                new ProductCategory(8, 4, 3)  // Cornflakes -> Ontbijt
            ];
        }

        public List<ProductCategory> GetAll()
        {
            return productCategories;
        }

        public List<ProductCategory> GetAllByCategoryId(int categoryId)
        {
            return productCategories.Where(pc => pc.CategoryId == categoryId).ToList();
        }

        public ProductCategory? Get(int id)
        {
            return productCategories.FirstOrDefault(pc => pc.Id == id);
        }

        public ProductCategory Add(ProductCategory item)
        {
            int newId = productCategories.Max(pc => pc.Id) + 1;
            item.Id = newId;
            productCategories.Add(item);
            return item;
        }

        public ProductCategory? Update(ProductCategory item)
        {
            ProductCategory? productCategory = productCategories.FirstOrDefault(pc => pc.Id == item.Id);
            if (productCategory == null) return null;
            productCategory.ProductId = item.ProductId;
            productCategory.CategoryId = item.CategoryId;
            return productCategory;
        }

        public ProductCategory? Delete(ProductCategory item)
        {
            ProductCategory? productCategory = productCategories.FirstOrDefault(pc => pc.Id == item.Id);
            if (productCategory == null) return null;
            productCategories.Remove(productCategory);
            return productCategory;
        }
    }
}