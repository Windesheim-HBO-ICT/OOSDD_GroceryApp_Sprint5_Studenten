using Grocery.Core.Models;

namespace Grocery.Core.Interfaces.Repositories
{
    public interface IProductCategoryRepository
    {
        List<ProductCategory> GetAll();
        List<ProductCategory> GetByCategoryId(int categoryId);
        ProductCategory Add(ProductCategory item);
        ProductCategory? Delete(ProductCategory item);
        ProductCategory? Update(ProductCategory item);
    }
}
