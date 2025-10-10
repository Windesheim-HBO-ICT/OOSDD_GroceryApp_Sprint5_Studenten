using Grocery.Core.Models;

namespace Grocery.Core.Interfaces.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();

        Product? GetById(int id);

        Product Add(Product item);

        Product? Delete(Product item);

        Product? Update(Product item);
    }
}
