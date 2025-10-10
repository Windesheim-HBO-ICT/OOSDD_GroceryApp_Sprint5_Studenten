using CommunityToolkit.Mvvm.ComponentModel;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.App.ViewModels
{
    public partial class ProductCategoriesViewModel : BaseViewModel
    {
        private readonly IProductCategoryService _productCategoryService;
        public ObservableCollection<ProductCategory> ProductCategories { get; set; } = [];

        [ObservableProperty]
        private Category category = new(0, "None");

        public ProductCategoriesViewModel(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }
        public void Load(Category category)
        {
            ProductCategories.Clear();

            List<ProductCategory> productCategories = _productCategoryService.Get(category.Id);
            foreach (var productCategory in productCategories)
                ProductCategories.Add(productCategory);
        }
        partial void OnCategoryChanged(Category category)
        {
            Load(category);
        }
    }
}
