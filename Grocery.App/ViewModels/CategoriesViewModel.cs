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
    public class CategoriesViewModel : BaseViewModel
    {
        private readonly ICategoryService _categoryService;

        public ObservableCollection<Category> Categories { get; } = new();

        public CategoriesViewModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            Title = "Categorieën";
            LoadCategoriesAsync();
        }

        private async void LoadCategoriesAsync()
        {
            var items = await _categoryService.GetAllAsync();
            Categories.Clear();
            foreach (var category in items)
                Categories.Add(category);
        }

        public ICommand SelectCategoryCommand => new Command<Category>(async (category) =>
        {
            if (category == null)
                return;

            await Shell.Current.GoToAsync($"productcategories?categoryId={category.Id}");
        });
    }
}