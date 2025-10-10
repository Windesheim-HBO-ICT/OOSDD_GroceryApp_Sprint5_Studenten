using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grocery.Core.Interfaces;
using Grocery.Core.Models;

namespace Grocery.Core.Data.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public async Task<IEnumerable<ProductCategory>> GetByCategoryIdAsync(int categoryId)
        {
            return await _productCategoryRepository.GetByCategoryIdAsync(categoryId);
        }

        public async Task AddAsync(ProductCategory productCategory)
        {
            await _productCategoryRepository.AddAsync(productCategory);
        }
    }
}