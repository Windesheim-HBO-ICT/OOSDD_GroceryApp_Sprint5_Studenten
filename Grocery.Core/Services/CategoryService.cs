using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using Grocery.Core.Interfaces.Repositories;

namespace Grocery.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Category>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }
    }
}
