using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using System.Collections.ObjectModel;

namespace Grocery.App.ViewModels
{
    public partial class ProductCategoriesViewModel : BaseViewModel
    {
        private readonly IProductCategoryService _service;

        public int CategoryId { get; set; }

        public ObservableCollection<string> ProductCategories { get; } = new();

        public ProductCategoriesViewModel(IProductCategoryService service)
        {
            _service = service;
        }

        public void Load()
        {
            ProductCategories.Clear();
            var items = _service.GetAll()
                .Where(pc => pc.CategoryId == CategoryId)
                .Select(pc => pc.Name);

            foreach (var name in items)
                ProductCategories.Add(name);
        }
    }
}
