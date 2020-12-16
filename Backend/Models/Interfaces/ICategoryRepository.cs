using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models.Interfaces
{
    interface ICategoryRepository
    {
        IList<Category> GetAll();
        Category GetById(int id);
        void Add(Category category);
        void Edit(Category category);
        void delete(Category category);
        Category GetByName(string name);
        int ProductCount(int categoryId);
    }
}
