using CommunityToolkit.Mvvm.ComponentModel;

namespace Grocery.Core.Models
{
    public partial class Product : Model
    {
        [ObservableProperty]
        public int stock;
        public int Prijs { get; set; }
        public DateOnly ShelfLife { get; set; }
        public Product(int id, string name, int stock, int prijs) : this(id, name, stock, prijs, default) { }

        public Product(int id, string name, int stock, int prijs, DateOnly shelfLife) : base(id, name) 
        {
            Stock = stock;
            Prijs = prijs;
            ShelfLife = shelfLife;
        }
        public override string? ToString()
        {
            return $"{Name} - {Stock} op voorraad";
        }
    }
}
