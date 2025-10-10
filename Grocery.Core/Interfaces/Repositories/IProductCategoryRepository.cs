using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Grocery.Core.Models;

namespace Grocery.Core.Interfaces
{
    public interface IProductCategoryRepository
    {
        Task<IEnumerable<ProductCategory>> GetByCategoryIdAsync(int categoryId);
        Task AddAsync(ProductCategory productCategory);
        Task DeleteAsync(int id);
    }
}