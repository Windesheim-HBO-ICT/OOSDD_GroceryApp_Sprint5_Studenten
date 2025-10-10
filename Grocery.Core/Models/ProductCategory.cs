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

        public int ProductId { get; set; }
        public int CategoryId { get; set; }

        // Navigatie
        public Product Product { get; set; }
        public Category Category { get; set; }
    }
}