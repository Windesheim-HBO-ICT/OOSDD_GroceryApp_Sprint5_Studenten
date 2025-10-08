using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Models;

namespace Grocery.Core.Data.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly List<ProductCategory> _productCategories;

        public ProductCategoryRepository(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;

            var products = _productRepository.GetAll();
            var categories = _categoryRepository.GetAllAsync().Result.ToList();

            _productCategories = new List<ProductCategory>
            {
                new ProductCategory
                {
                    Id = 1,
                    Name = "Melk",
                    ProductId = 1,
                    CategoryId = 2
                },
                new ProductCategory
                {
                    Id = 2,
                    Name = "Kaas",
                    ProductId = 2,
                    CategoryId = 2
                },
                new ProductCategory
                {
                    Id = 3,
                    Name = "Brood",
                    ProductId = 3,
                    CategoryId = 1
                },
                new ProductCategory
                {
                    Id = 4,
                    Name = "Cornflakes",
                    ProductId = 4,
                    CategoryId = 1
                }
            };
        }

        public List<ProductCategory> GetAll()
        {
            return _productCategories;
        }

        public List<ProductCategory> GetByCategoryId(int categoryId)
        {
            return _productCategories.Where(pc => pc.CategoryId == categoryId).ToList();
        }

        public ProductCategory Add(ProductCategory item)
        {
            throw new NotImplementedException();
        }

        public ProductCategory? Delete(ProductCategory item)
        {
            throw new NotImplementedException();
        }

        public ProductCategory? Update(ProductCategory item)
        {
            throw new NotImplementedException();
        }
    }
}
