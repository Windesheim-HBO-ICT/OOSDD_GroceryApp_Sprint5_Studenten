using Grocery.Core.Models;

namespace Grocery.Core.Interfaces.Services
{
    public interface IProductCategoryService
    {
        List<ProductCategory> GetAll();
        List<ProductCategory> GetByCategoryId(int categoryId);
        ProductCategory Add(ProductCategory item);
        ProductCategory? Delete(ProductCategory item);
        ProductCategory? Update(ProductCategory item);
    }
}
