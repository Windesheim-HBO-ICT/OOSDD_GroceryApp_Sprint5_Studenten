using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using Grocery.Core.Interfaces.Repositories;

namespace Grocery.Core.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _repository;

        public ProductCategoryService(IProductCategoryRepository repository)
        {
            _repository = repository;
        }

        public List<ProductCategory> GetAll()
        {
            return _repository.GetAll();
        }

        public List<ProductCategory> GetByCategoryId(int categoryId)
        {
            return _repository.GetByCategoryId(categoryId);
        }

        public ProductCategory Add(ProductCategory item)
        {
            return _repository.Add(item);
        }

        public ProductCategory? Delete(ProductCategory item)
        {
            return _repository.Delete(item);
        }

        public ProductCategory? Update(ProductCategory item)
        {
            return _repository.Update(item);
        }
    }
}
