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
                new ProductCategory(1, 1, 1),  // Melk -> Zuivel
                new ProductCategory(2, 2, 1),  // Kaas -> Zuivel
                new ProductCategory(3, 3, 3),  // Brood -> Bakkerij
                new ProductCategory(4, 4, 2)   // Cornflakes -> Ontbijtgranen
            ];
        }

        // Ontvangt alle product-categorieen van de repository.
        public List<ProductCategory> GetAll()
        {
            return productCategories;
        }

        // Onvangt alle product-categorieen voor een specifieke categorie.
        public List<ProductCategory> GetByCategoryId(int categoryId)
        {
            return productCategories.Where(pc => pc.CategoryId == categoryId).ToList();
        }

        // Ontvangt alle product-categorien voor een specifieke product.
        public List<ProductCategory> GetByProductId(int productId)
        {
            return productCategories.Where(pc => pc.ProductId == productId).ToList();
        }

        // Onvangt een product-categorie door zijn unieke indentificatie.
        public ProductCategory? Get(int id)
        {
            return productCategories.FirstOrDefault(pc => pc.Id == id);
        }

        // Voegt een nieuwe product-categorie toe in de repository.
        public ProductCategory Add(ProductCategory item)
        {
            int newId = productCategories.Any() ? productCategories.Max(pc => pc.Id) + 1 : 1;
            item.Id = newId;
            productCategories.Add(item);
            return item;
        }

        // Updates een al bestaande product-categorie in de repository.
        public ProductCategory? Update(ProductCategory item)
        {
            ProductCategory? productCategory = productCategories.FirstOrDefault(pc => pc.Id == item.Id);
            if (productCategory == null) return null;

            productCategory.ProductId = item.ProductId;
            productCategory.CategoryId = item.CategoryId;
            return productCategory;
        }

        // Verwijderd een product-categorie in de repository.
        public ProductCategory? Delete(ProductCategory item)
        {
            ProductCategory? productCategory = productCategories.FirstOrDefault(pc => pc.Id == item.Id);
            if (productCategory != null)
            {
                productCategories.Remove(productCategory);
            }
            return productCategory;
        }
    }
}