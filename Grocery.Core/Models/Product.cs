using CommunityToolkit.Mvvm.ComponentModel;

namespace Grocery.Core.Models
{
    public partial class Product : Model
    {
        [ObservableProperty]
        public int stock;
        public DateOnly ShelfLife { get; set; }
        public decimal Price { get; set; } // Toegevoegd prijsveld

        public Product(int id, string name, int stock, decimal price) : this(id, name, stock, price, default) { }

        public Product(int id, string name, int stock, decimal price, DateOnly shelfLife) : base(id, name) 
        {
            Stock = stock;
            Price = price;
            ShelfLife = shelfLife;
        }

        // Voor backwards compatibility
        public Product(int id, string name, int stock) : this(id, name, stock, 0, default) { }
        public Product(int id, string name, int stock, DateOnly shelfLife) : this(id, name, stock, 0, shelfLife) { }

        public override string? ToString()
        {
            return $"{Name} - {Stock} op voorraad - Prijs: €{Price:F2}";
        }
    }
}
