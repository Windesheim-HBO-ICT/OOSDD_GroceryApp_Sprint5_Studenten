using CommunityToolkit.Mvvm.ComponentModel;
using System.Diagnostics;

namespace Grocery.Core.Models
{
    // Vertegenwoordigt een product in het grocery systeem met informatie over voorraad, houdbaarheid en prijs.
    public partial class Product : Model
    {
        [ObservableProperty]
        private int stock;

        [ObservableProperty]
        private decimal price;

        public DateOnly ShelfLife { get; set; }

        // Initialiseert een nieuw exemplaar van de klasse Product zonder houdbaarheid.
        public Product(int id, string name, int stock) : this(id, name, stock, 0.00m, default) { }

        // Initialiseert een nieuw exemplaar van de klasse Product zonder prijs.
        public Product(int id, string name, int stock, DateOnly shelfLife) : this(id, name, stock, 0.00m, shelfLife) { }

        // Initialiseert een nieuw exemplaar van de klasse Product met alle eigenschappen.
        public Product(int id, string name, int stock, decimal price, DateOnly shelfLife) : base(id, name)
        {
            Stock = stock;
            Price = price;
            ShelfLife = shelfLife;
        }

        // Geeft een string representation van het product terug.
        public override string? ToString()
        {
            return $"{Name} - {Stock} op voorraad - €{Price:F2}";
        }
    }
}