using Grocery.App.ViewModels;

namespace Grocery.App.Views
{
    public partial class CategoriesView : ContentPage
    {
        // Initialiseert een nieuwe instance van de CategoriesView class.
        public CategoriesView(CategoriesViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        // Wordt aangeroepen wanneer de view zichtbaar wordt.
        // Triggert het laden van data in het ViewModel.
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is CategoriesViewModel viewModel)
            {
                viewModel.OnAppearing();
            }
        }

        // Wordt aangeroepen wanneer de view verdwijnt.
        // Ruimt resources op in het ViewModel.
        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            if (BindingContext is CategoriesViewModel viewModel)
            {
                viewModel.OnDisappearing();
            }
        }
    }
}