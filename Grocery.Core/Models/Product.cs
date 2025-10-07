using CommunityToolkit.Mvvm.ComponentModel;

namespace Grocery.Core.Models
{
    public partial class Product : Model
    {
        [ObservableProperty]
        public int stock;

        [ObservableProperty]
        public Decimal price;
        public DateOnly ShelfLife { get; set; }
        public Product(int id, string name, int stock) : this(id, name, stock, default, default) { }
        public Product(int id, string name, int stock, DateOnly shelfLife) : this(id, name, stock, shelfLife, default) { }

        public Product(int id, string name, int stock, DateOnly shelfLife, Decimal price) : base(id, name) 
        {
            Stock = stock;
            ShelfLife = shelfLife;
            Price = price;
        }
        public override string? ToString()
        {
            return $"{Name} - {Stock} op voorraad";
        }
    }
}
