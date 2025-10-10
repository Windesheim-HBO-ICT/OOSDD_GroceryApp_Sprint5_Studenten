using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace Grocery.App.ViewModels
{
    public class ProductCategoriesViewModel : BaseViewModel
    {
        private readonly IProductCategoryService _productCategoryService;
        private readonly ICategoryService _categoryService;
        private readonly int _categoryId;
        public ObservableCollection<ProductCategory> ProductCategories { get; set; }

        public ProductCategoriesViewModel(IProductCategoryService productCategoryService, ICategoryService categoryService, int categoryId)
        {
            _productCategoryService = productCategoryService;
            _categoryService = categoryService;
            _categoryId = categoryId;
            ProductCategories = new ObservableCollection<ProductCategory>(
                _productCategoryService.GetAll().Where(pc => pc.CategoryId == _categoryId)
            );
        }
    }
}
