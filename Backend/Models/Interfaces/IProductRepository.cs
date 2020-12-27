using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(int id);
        Task<Product> AddProduct(Product product);
        Task<Product> EditProduct(Product product);
        Task<Product> DeleteProduct(int id);
        Task<Product> GetByName(string name);
        Task<IEnumerable<Product>> Search(string name);
        
    }
}
