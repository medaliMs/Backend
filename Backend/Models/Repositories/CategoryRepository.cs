using Backend.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        readonly ProductContext context;

        public CategoryRepository(ProductContext context)
        {
            this.context = context;
        }
        public void Add(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
        }

        public void delete(Category category)
        {
            Category c1 = context.Categories.Find(category.CategoryId);
            if (c1 != null)
            {
                context.Categories.Remove(c1);
                context.SaveChanges();
            }
        }

        public void Edit(Category category)
        {
            Category c1 = context.Categories.Find(category.CategoryId);
            if (c1 != null)
            {
                c1.CategoryName = category.CategoryName;

            }
        }

        public IList<Category> GetAll()
        {
            return context.Categories.OrderBy(s => s.CategoryName).ToList();
        }

        public Category GetById(int id)
        {
            return context.Categories.Find(id);
        }

        public Category GetByName(string name)
        {
            return context.Categories.Find(name);
        }
        public int ProductCount(int categoryId)
        {
            return context.Products.Where(s => s.CategoryId == categoryId).Count();
        }
    }
}
