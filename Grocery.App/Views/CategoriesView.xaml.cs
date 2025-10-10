using Grocery.App.ViewModels;
using Grocery.Core.Models;

namespace Grocery.App.Views
{
    public partial class CategoriesView : ContentPage
    {
        public CategoriesView(CategoriesViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }

        private async void OnCategorySelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is Category category)
            {
                await Shell.Current.GoToAsync($"productcategories?categoryId={category.Id}");
            }
        }
    }
}
