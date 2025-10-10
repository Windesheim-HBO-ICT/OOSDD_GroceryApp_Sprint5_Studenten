using Grocery.Core.Models;

namespace Grocery.Core.Interfaces.Services
{
    public interface IProductCategoryService
    {
        List<ProductCategory> GetAll(); // Onvangt alle product-categorieen.

        List<Product> GetProductsByCategoryId(int categoryId); // Onvangt alle producten voor een specifieke categorie met alle product gegevens.

        List<Category> GetCategoriesByProductId(int productId); // Onvangt alle categorieen voor een specifieke product.

        ProductCategory? Get(int id); // Onvangt een product-categorie door zijn unieke identificatie.

        ProductCategory Add(ProductCategory item); // Voegt een nieuwe product-categorie toe.

        ProductCategory? Update(ProductCategory item); // Updates een al gemaakte product-categorie.

        ProductCategory? Delete(ProductCategory item); // Verwijderd een categorie.
    }
}