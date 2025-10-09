using Grocery.App.ViewModels;

namespace Grocery.App.Views
{
    public partial class ProductCategoriesView : ContentPage
    {
        public ProductCategoriesView(ProductCategoriesViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext is ProductCategoriesViewModel bindingContext)
            {
                bindingContext.OnAppearing();
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            if (BindingContext is ProductCategoriesViewModel bindingContext)
            {
                bindingContext.OnDisappearing();
            }
        }
    }
}