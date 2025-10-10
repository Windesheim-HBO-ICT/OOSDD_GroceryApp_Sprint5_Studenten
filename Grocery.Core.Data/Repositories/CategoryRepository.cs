using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Models;

namespace Grocery.Core.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly List<Category> categories;

        // Initializes the repository with sample category data.
        public CategoryRepository()
        {
            categories = [
                new Category(1, "Zuivel"),
                new Category(2, "Ontbijtgranen"),
                new Category(3, "Bakkerij"),
                new Category(4, "Diepvries")
            ];
        }

        // Ontvangt alle categorieen van de repository.
        public List<Category> GetAll()
        {
            return categories;
        }

        // Ontvangt een categorie door zijn unieke identificatie.
        public Category? Get(int id)
        {
            return categories.FirstOrDefault(c => c.Id == id);
        }

        // Voegt een nieuwe categorie toe in de repository.
        public Category Add(Category item)
        {
            int newId = categories.Any() ? categories.Max(c => c.Id) + 1 : 1;
            item.Id = newId;
            categories.Add(item);
            return item;
        }

        // Updates een al gemaakte categorie in de repository.
        public Category? Update(Category item)
        {
            Category? category = categories.FirstOrDefault(c => c.Id == item.Id);
            if (category == null) return null;

            category.Name = item.Name;
            return category;
        }

        // Verwidjerd een categorie van de repository.
        public Category? Delete(Category item)
        {
            Category? category = categories.FirstOrDefault(c => c.Id == item.Id);
            if (category != null)
            {
                categories.Remove(category);
            }
            return category;
        }

        // Checkt of een categorie met hetzelfde naam al bestaat.
        public bool Exists(string name)
        {
            return categories.Any(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}