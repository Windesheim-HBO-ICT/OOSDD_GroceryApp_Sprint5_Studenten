using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.App.Views;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using System.Collections.ObjectModel;

namespace Grocery.App.ViewModels
{
    public partial class CategoriesViewModel : BaseViewModel
    {
        private readonly ICategoryService _categoryService;

        // Observable collectie van alle categorieën voor databinding.
        public ObservableCollection<Category> Categories { get; set; }

        // Naam van de nieuw toe te voegen categorie.
        [ObservableProperty]
        public string newCategoryName = string.Empty;

        // Foutmelding die aan de gebruiker getoond wordt.
        [ObservableProperty]
        public string errorMessage = string.Empty;

        // Initialiseert een nieuwe instance van de CategoriesViewModel class.
        public CategoriesViewModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            Title = "Categorieën";
            Categories = new ObservableCollection<Category>();
            LoadCategories();
        }

        // Laadt alle categorieën vanuit de service in de observable collectie.
        private void LoadCategories()
        {
            Categories.Clear();
            List<Category> categories = _categoryService.GetAll();
            foreach (Category category in categories)
            {
                Categories.Add(category);
            }
        }

        // Voegt een nieuwe categorie toe na validatie.
        [RelayCommand]
        private void AddCategory()
        {
            ErrorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(NewCategoryName))
            {
                ErrorMessage = "Categorienaam mag niet leeg zijn.";
                return;
            }

            if (!_categoryService.IsCategoryNameUnique(NewCategoryName))
            {
                ErrorMessage = "Categorie bestaat al.";
                return;
            }

            Category newCategory = new(0, NewCategoryName);
            Category? addedCategory = _categoryService.Add(newCategory);

            if (addedCategory != null)
            {
                Categories.Add(addedCategory);
                NewCategoryName = string.Empty;
            }
            else
            {
                ErrorMessage = "Categorie kon niet worden toegevoegd.";
            }
        }

        // Navigeert naar de ProductCategoriesView voor de geselecteerde categorie.
        [RelayCommand]
        private async Task SelectCategory(Category category)
        {
            if (category == null) return;

            Dictionary<string, object> parameter = new()
            {
                { nameof(Category), category }
            };

            await Shell.Current.GoToAsync(
                $"{nameof(ProductCategoriesView)}?CategoryName={category.Name}",
                true,
                parameter);
        }

        // Herlaadt categorieën wanneer de view zichtbaar wordt.
        public override void OnAppearing()
        {
            base.OnAppearing();
            LoadCategories();
        }

        // Ruimt resources op wanneer de view verdwijnt.
        public override void OnDisappearing()
        {
            base.OnDisappearing();
            ErrorMessage = string.Empty;
        }
    }
}