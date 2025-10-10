namespace Grocery.Core.Models
{
    // Representeerd de veel-op-veel relatie tussen producten en categorieen.
    public class ProductCategory : Model
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }

        // Navigation property naar het juiste product.
        public Product Product { get; set; } = new(0, "None", 0);

        // Navigation property naar het juiste categorie.
        public Category Category { get; set; } = new(0, "None");

        // Initialiseerd een nieuwe instance van de ProductCategory class.
        public ProductCategory(int id, int productId, int categoryId) : base(id, "")
        {
            ProductId = productId;
            CategoryId = categoryId;
        }
    }
}