using System.Threading.Tasks;
using Grocery.App.ViewModels;

namespace Grocery.App.Views;

public partial class ProductCategoriesView : ContentPage
{
    private readonly ProductCategoriesViewModel _viewModel;
	public ProductCategoriesView(ProductCategoriesViewModel viewModel, int categoryId)
	{
        InitializeComponent();
        _viewModel = viewModel;
        _viewModel.CategoryId = categoryId;
		BindingContext = _viewModel = viewModel;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.Load();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        if (BindingContext is CategoriesViewModel bindingContext)
        {
            bindingContext.OnDisappearing();
        }
    }
}