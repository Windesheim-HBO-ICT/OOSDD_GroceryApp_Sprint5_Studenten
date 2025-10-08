using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Core.Models
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; } 
        public int CategoryId { get; set; }

        public ProductCategory() { }
        public ProductCategory(int id, string name, int productId, int categoryId)
        {
            Id = id;
            Name = name;
            ProductId = productId;
            CategoryId = categoryId;
        }
        public override string? ToString()
        {
            return Name;
        }
        public Product? Product { get; set; }
        public Category? Category { get; set; }
    }
}
