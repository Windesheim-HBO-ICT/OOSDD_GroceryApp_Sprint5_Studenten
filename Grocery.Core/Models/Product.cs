using CommunityToolkit.Mvvm.ComponentModel;

namespace Grocery.Core.Models
{
    public partial class Product : Model
    {
        [ObservableProperty]
        public int stock;
        public DateOnly ShelfLife { get; set; }
        public double Price { get; set; }
        public Product(int id, string name, int stock, double price) : this(id, name, stock, price, default) { }

        public Product(int id, string name, int stock, double price, DateOnly shelfLife) : base(id, name) 
        {
            Stock = stock;
            ShelfLife = shelfLife;
            Price = price;
        }
        public override string? ToString()
        {
            return $"{Name} - {Stock} op voorraad";
        }

        public List<ProductCategory> ProductCategories { get; set; } = new();
    }
}
