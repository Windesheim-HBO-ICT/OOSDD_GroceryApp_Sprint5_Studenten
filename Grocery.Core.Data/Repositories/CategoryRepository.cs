using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Models;

namespace Grocery.Core.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly List<Category> _categories = new()
        {
            new Category { Id = 1, Name = "Fruit" },
            new Category { Id = 2, Name = "Zuivel" },
            new Category { Id = 3, Name = "Groente" },
            new Category { Id = 4, Name = "Snacks" }
        };

        public IEnumerable<Category> GetAll() => _categories;

        public Category? GetById(int id) => _categories.FirstOrDefault(c => c.Id == id);
    }
}

