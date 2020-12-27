using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategory(int id);
        Task<Category> AddCategory(Category category);
        Task<Category> EditCategory(Category category);
        Task<Category> delete(int categoryid);
        Task<Category> GetByName(string name);
        int ProductCount(int categoryId);
    }
}
