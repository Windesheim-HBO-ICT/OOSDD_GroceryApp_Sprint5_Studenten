using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using System.Collections.Generic;

namespace Grocery.Core.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _repo;
        public ProductCategoryService(IProductCategoryRepository repo) => _repo = repo;
        public List<ProductCategory> GetAll() => _repo.GetAll();
        public ProductCategory? Get(int id) => _repo.Get(id);
    }
}
