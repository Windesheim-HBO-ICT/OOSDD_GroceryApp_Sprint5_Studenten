using Grocery.Core.Models;

namespace Grocery.Core.Interfaces.Repositories
{
    public interface IProductCategoryRepository
    {
        List<ProductCategory> GetAll(); // Geeft alle product-gategorieen terug.

        List<ProductCategory> GetByCategoryId(int categoryId); // Geeft alle product-gategorieen van een specifiek categorie.

        List<ProductCategory> GetByProductId(int productId); // Geeft alle product-gategorieen van een specifiek product.

        ProductCategory? Get(int id); // Geeft product-categorie terug met gebruik van unieke identificatie.

        ProductCategory Add(ProductCategory item); // Maakt nieuwe product-categorie aan.

        ProductCategory? Update(ProductCategory item); // Updates al gemaakte product-categorie.

        ProductCategory? Delete(ProductCategory item); // Verwijderd een product-categorie.
    }
}