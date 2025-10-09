using CommunityToolkit.Mvvm.ComponentModel;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using System.Collections.ObjectModel;

namespace Grocery.App.ViewModels
{
    [QueryProperty(nameof(Category), nameof(Category))]
    public partial class ProductCategoriesViewModel : BaseViewModel
    {
        private readonly IProductCategoryService _productCategoryService;
        public ObservableCollection<Product> Products { get; set; } = [];

        [ObservableProperty]
        Category category = new(0, "None");

        public ProductCategoriesViewModel(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        partial void OnCategoryChanged(Category value)
        {
            Title = value.Name;
            LoadProducts(value.Id);
        }

        private void LoadProducts(int categoryId)
        {
            Products.Clear();
            var productCategories = _productCategoryService.GetAllByCategoryId(categoryId);
            foreach (var pc in productCategories)
            {
                Products.Add(pc.Product);
            }
        }

        public override void OnAppearing()
        {
            base.OnAppearing();
            if (Category != null && Category.Id > 0)
            {
                LoadProducts(Category.Id);
            }
        }

        public override void OnDisappearing()
        {
            base.OnDisappearing();
            Products.Clear();
        }
    }
}