using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Models;

namespace Grocery.Core.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly List<Category> categories;

        public CategoryRepository()
        {
            categories = [
                new Category(1, "Zuivel"),
                new Category(2, "Brood en graanproducten"),
                new Category(3, "Ontbijt"),
                new Category(4, "Verse producten")
            ];
        }

        public List<Category> GetAll()
        {
            return categories;
        }

        public Category? Get(int id)
        {
            return categories.FirstOrDefault(c => c.Id == id);
        }

        public Category Add(Category item)
        {
            int newId = categories.Max(c => c.Id) + 1;
            item.Id = newId;
            categories.Add(item);
            return item;
        }

        public Category? Update(Category item)
        {
            Category? category = categories.FirstOrDefault(c => c.Id == item.Id);
            if (category == null) return null;
            category.Name = item.Name;
            return category;
        }

        public Category? Delete(Category item)
        {
            Category? category = categories.FirstOrDefault(c => c.Id == item.Id);
            if (category == null) return null;
            categories.Remove(category);
            return category;
        }
    }
}