using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.App.Views;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace Grocery.App.ViewModels
{
    [QueryProperty(nameof(Category), nameof(Category))]
    public partial class ProductCategoriesViewModel : BaseViewModel
    {
        private readonly IProductCategoryService _productCategoryService;
        private readonly IProductService _productService;
        private string searchText = "";
        public ObservableCollection<ProductCategory> MyProductCategories { get; set; } = [];
        public ObservableCollection<Product> OtherProducts { get; set; } = [];

        [ObservableProperty]
        Category category = new(0, "None");

        public ProductCategoriesViewModel(IProductCategoryService productCategoryService, IProductService productService)
        {
            _productCategoryService = productCategoryService;
            _productService = productService;
            Load(category.Id);
        }

        private void Load(int id)
        {
            MyProductCategories.Clear();
            foreach (var item in _productCategoryService.GetAllInCategory(id)) MyProductCategories.Add(item);
            GetOtherProducts();
        }

        private void GetOtherProducts()
        {
            OtherProducts.Clear();
            foreach (Product p in _productService.GetAll())
                if (MyProductCategories.FirstOrDefault(g => g.ProductId == p.Id) == null  && (searchText=="" || p.Name.ToLower().Contains(searchText.ToLower())))
                    OtherProducts.Add(p);
        }

        partial void OnCategoryChanged(Category value)
        {
            Load(value.Id);
        }

        [RelayCommand]
        public void AddProduct(Product product)
        {
            if (product == null) return;
            ProductCategory item = new(0, "None", product.Id, category.Id);
            _productCategoryService.Add(item);
            OtherProducts.Remove(product);
            OnCategoryChanged(category);
        }

        [RelayCommand]
        public void PerformSearch(string searchText)
        {
            this.searchText = searchText;
            GetOtherProducts();
        }
    }
}
