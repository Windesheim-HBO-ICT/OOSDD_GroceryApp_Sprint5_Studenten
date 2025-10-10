using System.Collections.Generic;
using Grocery.Core.Models;

namespace Grocery.Core.Interfaces.Services
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category? Get(int id);
    }
}
