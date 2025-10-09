using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using System.ComponentModel.Design;

namespace Grocery.Core.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IProductRepository _productRepository;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository, IProductRepository productRepository)
        {
            _productCategoryRepository = productCategoryRepository;
            _productRepository = productRepository;
        }

        public List<ProductCategory> GetAll()
        {
            List<ProductCategory> productCategories = _productCategoryRepository.GetAll();
            FillService(productCategories);
            return productCategories;
        }

        public ProductCategory Add(ProductCategory item)
        {
            int maxId = _productCategoryRepository.GetAll().Max(x => x.Id);
            item.Id = maxId + 1;
            _productCategoryRepository.Add(item);
            return item;
        }

        public ProductCategory? Delete(ProductCategory item)
        {
            throw new NotImplementedException();
        }

        public ProductCategory? Get(int id)
        {
            throw new NotImplementedException();
        }

        public ProductCategory? Update(ProductCategory item)
        {
            return _productCategoryRepository.Update(item);
        }
        public List<ProductCategory> GetAllInCategory(int id)
        {
            List<ProductCategory> productCategories = _productCategoryRepository.GetAll().FindAll(x => x.CategoryId == id);
            FillService(productCategories);
            return productCategories;
        }
        private void FillService(List<ProductCategory> productCategories)
        {
            foreach (ProductCategory p in productCategories)
            {
                p.Product = _productRepository.Get(p.ProductId) ?? new(0, "", 0, 0);
            }
        }

    }
}
