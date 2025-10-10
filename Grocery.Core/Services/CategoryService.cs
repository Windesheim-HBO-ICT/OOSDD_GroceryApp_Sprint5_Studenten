using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;

namespace Grocery.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        // Initialiseerd een nieuwe instance van de CategoryService class.
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // Ontvangt alle categorieen van de repository.
        public List<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        // Onvangt een categorie door zijn unieke identificatie.
        public Category? Get(int id)
        {
            return _categoryRepository.Get(id);
        }

        // Voegt een nieuwe categorie na het valideren.
        public Category? Add(Category item)
        {
            if (_categoryRepository.Exists(item.Name))
            {
                return null;
            }
            return _categoryRepository.Add(item);
        }

        // Updates een al gemaatke categorie in de repository.
        public Category? Update(Category item)
        {
            return _categoryRepository.Update(item);
        }

        // Verwijderd een categorie van de repository.
        public Category? Delete(Category item)
        {
            return _categoryRepository.Delete(item);
        }

        // Valideert of een categorie naam al in gebruik is.
        public bool IsCategoryNameUnique(string name)
        {
            return !_categoryRepository.Exists(name);
        }
    }
}