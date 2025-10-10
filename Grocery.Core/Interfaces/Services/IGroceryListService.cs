using Grocery.Core.Models;

namespace Grocery.Core.Interfaces.Services
{
    public interface IGroceryListService
    {
        public List<GroceryList> GetAll();
        public GroceryList Add(GroceryList item);

        public GroceryList? Delete(GroceryList item);

        public GroceryList? GetById(int id);

        public GroceryList? Update(GroceryList item);
    }
}
