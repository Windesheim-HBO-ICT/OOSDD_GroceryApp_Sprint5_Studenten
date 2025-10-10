using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace Grocery.Core.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly List<Category> categories = new()
        {
            new Category(1, "Zuivel"),
            new Category(2, "Bakkerij"),
            new Category(3, "Ontbijtgranen")
        };

        public List<Category> GetAll() => categories;
        public Category? Get(int id) => categories.FirstOrDefault(c => c.Id == id);
        public Category Add(Category category) { categories.Add(category); return category; }
        public Category? Delete(Category category) { categories.Remove(category); return category; }
        public Category? Update(Category category)
        {
            var cat = categories.FirstOrDefault(c => c.Id == category.Id);
            if (cat == null) return null;
            cat.Name = category.Name;
            return cat;
        }
    }
}
