using CommunityToolkit.Mvvm.ComponentModel;
using System.Diagnostics;

namespace Grocery.Core.Models
{
    public partial class Product : Model
    {
        [ObservableProperty]
        public int stock;

        [ObservableProperty]
        public decimal price;

        public DateOnly ShelfLife { get; set; }
        public Product(int id, string name, int stock)
        : this(id, name, stock, default, 0m) { }

        public Product(int id, string name, int stock, DateOnly shelfLife, decimal price = 0m)
        : base(id, name)
        {
            Stock = stock;
            ShelfLife = shelfLife;
            Price = price;
        }
        public override string? ToString()
        {
            return $"{Name} - {Stock} op voorraad - €{Price:F2}";
        }
    }
}
