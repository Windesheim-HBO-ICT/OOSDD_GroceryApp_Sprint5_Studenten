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
    public partial class CategoriesViewModel : ObservableObject
    {
        private readonly CategoryService _categoryService;

        [ObservableProperty]
        private ObservableCollection<Category> categories = new();

        public CategoriesViewModel(CategoryService categoryService)
        {
            _categoryService = categoryService;
            LoadCategories();
        }

        private void LoadCategories()
        {
            Categories.Clear();
            foreach (var category in _categoryService.GetCategories())
                Categories.Add(category);
        }
    }
}
