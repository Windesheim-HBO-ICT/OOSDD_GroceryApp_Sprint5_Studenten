using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommunityToolkit.Mvvm.ComponentModel;
using Grocery.Core.Models;
using Grocery.Core.Services;
using System.Collections.ObjectModel;

namespace Grocery.App.ViewModels
{
    [QueryProperty(nameof(CategoryId), "categoryId")]
    public partial class ProductCategoriesViewModel : ObservableObject
    {
        private readonly ProductCategoryService _productCategoryService;

        [ObservableProperty]
        private int categoryId;

        [ObservableProperty]
        private ObservableCollection<Product> products = new();

        public ProductCategoriesViewModel(ProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        public void LoadProducts()
        {
            Products.Clear();
            foreach (var p in _productCategoryService.GetProductsByCategory(CategoryId))
                Products.Add(p);
        }
    }
}
