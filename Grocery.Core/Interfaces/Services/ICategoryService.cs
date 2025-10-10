using Grocery.Core.Models;

namespace Grocery.Core.Interfaces.Services
{
    public interface ICategoryService
    {
        List<Category> GetAll(); // Onvangt alle categorieen.

        Category? Get(int id); // Ontvangt een categorie door zijn unieke indentificatie.

        Category? Add(Category item); // Voegt een nieuwe categorie toe.

        Category? Update(Category item); // Updates een al gemaakte categorie.

        Category? Delete(Category item); // Verwijderd een categorie.

        bool IsCategoryNameUnique(string name); // Valideert of de categorie naam al bestaat.
    }
}