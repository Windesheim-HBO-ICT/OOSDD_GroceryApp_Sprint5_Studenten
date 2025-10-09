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
        public ObservableCollection<Category> Categories { get; set; }

        public CategoriesViewModel(ICategoryService categoryService)
        {
            Title = "Categorieën";
            _categoryService = categoryService;
            Categories = new(_categoryService.GetAll());
        }

        [RelayCommand]
        public async Task SelectCategory(Category category)
        {
            Dictionary<string, object> parameter = new() { { nameof(Category), category } };
            await Shell.Current.GoToAsync($"{nameof(ProductCategoriesView)}?CategoryName={category.Name}", true, parameter);
        }

        public override void OnAppearing()
        {
            base.OnAppearing();
            Categories.Clear();
            foreach (var category in _categoryService.GetAll())
            {
                Categories.Add(category);
            }
        }

        public override void OnDisappearing()
        {
            base.OnDisappearing();
            Categories.Clear();
        }
    }
}