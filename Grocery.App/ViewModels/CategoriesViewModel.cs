using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using Grocery.App.Views;


namespace Grocery.App.ViewModels
{
    public partial class CategoriesViewModel : BaseViewModel
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductCategoryService _productCategoryService;

        private IEnumerable<Category> categories;

        public CategoriesViewModel(ICategoryService categoryService, IProductCategoryService productCategoryService)
        {
            _categoryService = categoryService;
            _productCategoryService = productCategoryService;
            LoadCategories = new AsyncRelayCommand(LoadCategoriesAsync);
        }

        public AsyncRelayCommand LoadCategories { get; }

        private async Task LoadCategoriesAsync ()
        {
            Categories = await _categoryService.GetAllAsync();
        }

        public async Task CategorySelected(Category category)
        {
            if (category == null)
                return;
            var viewModel = new ProductCategoriesViewModel(_productCategoryService)
            {
                CategoryId = category.Id,
            };

            var view = new ProductCategoriesView(viewModel, category.Id);

            await Shell.Current.Navigation.PushAsync(view);
        }

        public IEnumerable<Category> Categories
        {
            get => categories;
            set => SetProperty(ref categories, value);
        }
    }
}
