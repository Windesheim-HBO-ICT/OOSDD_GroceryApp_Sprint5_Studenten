using Grocery.Core.Models;

namespace Grocery.Core.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetAll(); // Geeft alle categorien terug.

        Category? Get(int id); // Geeft categorie terug met unieke identificatie.

        Category Add(Category item); // Maakt nieuwe categorie aan.

        Category? Update(Category item); // Updates al gemaakte categorie.

        Category? Delete(Category item); // Verwijderd een categorie.

        bool Exists(string name); // Checkt of een categorie met hetzelfde naam al bestaat.
    }
}