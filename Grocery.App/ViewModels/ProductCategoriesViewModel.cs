using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using System.Collections.ObjectModel;

namespace Grocery.App.ViewModels
{
    [QueryProperty(nameof(Category), nameof(Category))]
    public partial class ProductCategoriesViewModel : BaseViewModel
    {
        private readonly IProductCategoryService _productCategoryService;
        private string searchText = string.Empty;
        private List<Product> allProducts = new();

        // Observable collectie van gefilterde producten voor databinding.
        public ObservableCollection<Product> FilteredProducts { get; set; }

        // De geselecteerde categorie.
        [ObservableProperty]
        private Category category = new(0, "Geen categorie");

        // Initialiseert een nieuwe instance van de ProductCategoriesViewModel class.
        public ProductCategoriesViewModel(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
            FilteredProducts = new ObservableCollection<Product>();
        }

        // Wordt aangeroepen wanneer de Category property verandert.
        // Laadt producten voor de nieuwe categorie.
        partial void OnCategoryChanged(Category value)
        {
            if (value != null)
            {
                Title = value.Name;
                LoadProducts(value.Id);
            }
        }

        // Laadt alle producten voor de opgegeven categorie.
        private void LoadProducts(int categoryId)
        {
            allProducts = _productCategoryService.GetProductsByCategoryId(categoryId);
            ApplyFilter();
        }

        // Past de zoekfilter toe op de productlijst.
        private void ApplyFilter()
        {
            FilteredProducts.Clear();

            foreach (Product product in allProducts)
            {
                if (IsProductMatchingSearch(product))
                {
                    FilteredProducts.Add(product);
                }
            }
        }

        // Controleert of een product voldoet aan de zoekterm.
        private bool IsProductMatchingSearch(Product product)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                return true;
            }

            return product.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase);
        }

        // Voert een zoekopdracht uit op de productlijst.
        // Command handler voor de SearchBar.
        [RelayCommand]
        private void PerformSearch(string searchQuery)
        {
            searchText = searchQuery ?? string.Empty;
            ApplyFilter();
        }

        // Herlaadt producten wanneer de view zichtbaar wordt.
        public override void OnAppearing()
        {
            base.OnAppearing();

            if (Category != null && Category.Id != 0)
            {
                LoadProducts(Category.Id);
            }
        }

        // Ruimt resources op wanneer de view verdwijnt.
        public override void OnDisappearing()
        {
            base.OnDisappearing();
            FilteredProducts.Clear();
            searchText = string.Empty;
        }
    }
}