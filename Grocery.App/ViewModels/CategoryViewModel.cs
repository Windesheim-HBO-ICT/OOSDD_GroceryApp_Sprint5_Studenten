using Grocery.Core.Interfaces.Services;
using CommunityToolkit.Mvvm.Input;
using Grocery.Core.Models;
using System.Collections.ObjectModel;

namespace Grocery.App.ViewModels
{
    public partial class CategoryViewModel : BaseViewModel
    {
        private readonly ICategoryService _categoryService;
        public ObservableCollection<Category> Categories { get; set; }

        public CategoryViewModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            Categories = [];
            foreach (Category c in _categoryService.GetAll()) Categories.Add(c);
        }

        [RelayCommand]
        public async Task SelectCategory(Category category)
        {
            Dictionary<string, object> paramater = new() { { nameof(Category), category } };
            await Shell.Current.GoToAsync($"{nameof(Views.ProductCategoryView)}?Title={category.Name}", true, paramater);
        }
    }

}
