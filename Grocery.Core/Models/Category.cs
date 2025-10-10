using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Core.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigatie naar koppeltabel
        public ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
    }
}