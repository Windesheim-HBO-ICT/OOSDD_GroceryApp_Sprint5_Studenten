using Grocery.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Core.Interfaces.Services
{
   public interface IProductCategoryService
    {
        public List<ProductCategory> GetAll();
        public List<ProductCategory> Get(int id);
    }
}
