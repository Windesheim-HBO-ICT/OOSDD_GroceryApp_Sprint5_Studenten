using System.Collections.Generic;
using Grocery.Core.Models;

namespace Grocery.Core.Interfaces.Services
{
    public interface IProductCategoryService
    {
        List<ProductCategory> GetAll();
        ProductCategory? Get(int id);
    }
}
