using System.Threading.Tasks;
using Grocery.Core.Models;
using Grocery.App.ViewModels;

namespace Grocery.App.Views;

public partial class CategoriesView : ContentPage
{
    private CategoriesViewModel _viewModel;
    public CategoriesView(CategoriesViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is CategoriesViewModel bindingContext)
        {
            bindingContext.OnAppearing();

        }
        await _viewModel.LoadCategories.ExecuteAsync(null);
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        if (BindingContext is CategoriesViewModel bindingContext)
        {
            bindingContext.OnDisappearing();
        }
    }

    private async void OnCategorySelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Category category && BindingContext is CategoriesViewModel bindingContext)
        {
            await bindingContext.CategorySelected(category);
        }

        ((CollectionView)sender).SelectedItem = null;
    }
}