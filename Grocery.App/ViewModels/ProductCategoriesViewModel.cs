using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grocery.Core.Interfaces;
using Grocery.Core.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Grocery.App.ViewModels
{
    [QueryProperty(nameof(CategoryId), "categoryId")]
    public class ProductCategoriesViewModel : BaseViewModel
    {
        private readonly IProductCategoryService _productCategoryService;
        private readonly ICategoryService _categoryService;

        public ObservableCollection<Product> Products { get; } = new();

        private int categoryId;
        public int CategoryId
        {
            get => categoryId;
            set
            {
                categoryId = value;
                LoadProductsAsync();
            }
        }

        public ProductCategoriesViewModel(
            IProductCategoryService productCategoryService,
            ICategoryService categoryService)
        {
            _productCategoryService = productCategoryService;
            _categoryService = categoryService;
            Title = "Producten in categorie";
        }

        private async void LoadProductsAsync()
        {
            Products.Clear();

            // Get product-category relations
            var productCategories = await _productCategoryService.GetByCategoryIdAsync(CategoryId);

            // Extract the actual Product objects
            foreach (var pc in productCategories)
            {
                if (pc.Product != null)
                    Products.Add(pc.Product);
            }

            // Optional: update title dynamically
            var category = await _categoryService.GetByIdAsync(CategoryId);
            if (category != null)
                Title = $"Categorie: {category.Name}";
        }

        public ICommand GoBackCommand => new Command(async () =>
        {
            await Shell.Current.GoToAsync("..");
        });
    }
}