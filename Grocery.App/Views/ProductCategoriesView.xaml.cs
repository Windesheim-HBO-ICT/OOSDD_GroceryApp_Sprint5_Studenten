namespace Grocery.App.Views;

public partial class ProductCategoriesView : ContentPage
{
    public ProductCategoriesView(ViewModels.ProductCategoriesViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}