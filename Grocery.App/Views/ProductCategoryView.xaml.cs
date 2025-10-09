using Grocery.App.ViewModels;

namespace Grocery.App.Views;

public partial class ProductCategoryView : ContentPage
{
	public ProductCategoryView(ProductCategoriesViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}
