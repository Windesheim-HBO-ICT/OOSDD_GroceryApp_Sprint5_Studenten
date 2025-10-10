public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; } // Moet aanwezig zijn

    public Product(int id, string name, decimal price)
    {
        Id = id;
        Name = name;
        Price = price;
    }
}

<Label Text="{Binding Price, StringFormat='€{0:F2}'}" Grid.Column="1"/>

public ObservableCollection<Product> Products { get; set; }

public MainViewModel()
{
    var repo = new ProductRepository();
    Products = new ObservableCollection<Product>(repo.GetProducts());
}

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainViewModel();
    }
}