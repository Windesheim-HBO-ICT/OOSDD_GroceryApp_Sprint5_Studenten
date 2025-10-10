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

        // Initialiseert een nieuwe instance van de ProductCategoryService class.
        public ProductCategoryService(
            IProductCategoryRepository productCategoryRepository,
            IProductRepository productRepository,
            ICategoryRepository categoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        // Ontvangt alle product-categorieen van de repository.
        public List<ProductCategory> GetAll()
        {
            List<ProductCategory> productCategories = _productCategoryRepository.GetAll();
            EnrichWithNavigationProperties(productCategories);
            return productCategories;
        }

        // Ontvangt alle producten voor een specifieke categorie met volledige product gegevens.
        public List<Product> GetProductsByCategoryId(int categoryId)
        {
            List<ProductCategory> productCategories = _productCategoryRepository.GetByCategoryId(categoryId);
            List<Product> products = new();

            foreach (ProductCategory pc in productCategories)
            {
                Product? product = _productRepository.Get(pc.ProductId);
                if (product != null)
                {
                    products.Add(product);
                }
            }

            return products;
        }

        // Ontvangt alle categorieën voor een specifiek product.
        public List<Category> GetCategoriesByProductId(int productId)
        {
            List<ProductCategory> productCategories = _productCategoryRepository.GetByProductId(productId);
            List<Category> categories = new();

            foreach (ProductCategory pc in productCategories)
            {
                Category? category = _categoryRepository.Get(pc.CategoryId);
                if (category != null)
                {
                    categories.Add(category);
                }
            }

            return categories;
        }

        // Ontvangt een product-categorie door zijn unieke identificatie.
        public ProductCategory? Get(int id)
        {
            ProductCategory? productCategory = _productCategoryRepository.Get(id);
            if (productCategory != null)
            {
                EnrichWithNavigationProperties(new List<ProductCategory> { productCategory });
            }
            return productCategory;
        }

        // Voegt een nieuwe product-categorie toe aan de repository.
        public ProductCategory Add(ProductCategory item)
        {
            return _productCategoryRepository.Add(item);
        }

        // Update een bestaande product-categorie in de repository.
        public ProductCategory? Update(ProductCategory item)
        {
            return _productCategoryRepository.Update(item);
        }

        // Verwijdert een product-categorie uit de repository.
        public ProductCategory? Delete(ProductCategory item)
        {
            return _productCategoryRepository.Delete(item);
        }

        // Verrijkt product-categorie objecten met navigation properties.
        private void EnrichWithNavigationProperties(List<ProductCategory> productCategories)
        {
            foreach (ProductCategory pc in productCategories)
            {
                pc.Product = _productRepository.Get(pc.ProductId) ?? new(0, "Onbekend", 0);
                pc.Category = _categoryRepository.Get(pc.CategoryId) ?? new(0, "Onbekend");
            }
        }
    }
}