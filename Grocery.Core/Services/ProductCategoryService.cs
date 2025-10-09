using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;

namespace Grocery.Core.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository,
                                     IProductRepository productRepository,
                                     ICategoryRepository categoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public List<ProductCategory> GetAll()
        {
            List<ProductCategory> productCategories = _productCategoryRepository.GetAll();
            FillService(productCategories);
            return productCategories;
        }

        public List<ProductCategory> GetAllByCategoryId(int categoryId)
        {
            List<ProductCategory> productCategories = _productCategoryRepository.GetAllByCategoryId(categoryId);
            FillService(productCategories);
            return productCategories;
        }

        public ProductCategory? Get(int id)
        {
            ProductCategory? productCategory = _productCategoryRepository.Get(id);
            if (productCategory != null)
            {
                productCategory.Product = _productRepository.Get(productCategory.ProductId) ?? new(0, "None", 0);
                productCategory.Category = _categoryRepository.Get(productCategory.CategoryId) ?? new(0, "None");
            }
            return productCategory;
        }

        public ProductCategory Add(ProductCategory item)
        {
            return _productCategoryRepository.Add(item);
        }

        public ProductCategory? Update(ProductCategory item)
        {
            return _productCategoryRepository.Update(item);
        }

        public ProductCategory? Delete(ProductCategory item)
        {
            return _productCategoryRepository.Delete(item);
        }

        private void FillService(List<ProductCategory> productCategories)
        {
            foreach (ProductCategory pc in productCategories)
            {
                pc.Product = _productRepository.Get(pc.ProductId) ?? new(0, "None", 0);
                pc.Category = _categoryRepository.Get(pc.CategoryId) ?? new(0, "None");
            }
        }
    }
}