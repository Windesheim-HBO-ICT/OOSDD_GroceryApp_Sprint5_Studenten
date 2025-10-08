namespace Grocery.Core.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public override string? ToString()
        {
            return Name;
        }
        public List<ProductCategory> ProductCategories { get; set; } = new();
    }
}
