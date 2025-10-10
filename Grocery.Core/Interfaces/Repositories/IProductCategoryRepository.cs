using System.Collections.Generic;
using Grocery.Core.Models;

namespace Grocery.Core.Interfaces.Repositories
{
    public interface IProductCategoryRepository
    {
        List<ProductCategory> GetAll();
        ProductCategory? Get(int id);
        ProductCategory Add(ProductCategory productCategory);
        ProductCategory? Delete(ProductCategory productCategory);
        ProductCategory? Update(ProductCategory productCategory);
    }
}
