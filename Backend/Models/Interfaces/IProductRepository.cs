using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models.Interfaces
{
    interface IProductRepository
    {
        IList<Product> GetAll();
        Product GetById(int id);
        void Add(Product product);
        void Edit(Product product);
        void Delete(Product product);
        IList<Product> GetProductsByCategoryID(int? categoryId);
        IList<Product> FindByName(string name);
    }
}
