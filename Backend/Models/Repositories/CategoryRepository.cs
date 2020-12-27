using Backend.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
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
        public async Task<Category> AddCategory(Category category)
        {
            var result = await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Category> delete(int categoryid)
        {
            var result = await context.Categories.FirstOrDefaultAsync(c => c.CategoryId == categoryid);
            if(result != null)
            {
                context.Categories.Remove(result);
                await context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Category> EditCategory(Category category)
        {
            var result = await context.Categories.FirstOrDefaultAsync(c => c.CategoryId == category.CategoryId);
            if(result != null)
            {
                result.CategoryName = category.CategoryName;
                result.Image = category.Image;
                await context.SaveChangesAsync();

                return result;
            }
            return null;

        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await context.Categories.ToListAsync();
        }

        public async  Task<Category> GetCategory(int id)
        {
            return await context.Categories.FirstOrDefaultAsync(c => c.CategoryId == id);
        }

        public async Task<Category> GetByName(string name)
        {
            return await context.Categories.FirstOrDefaultAsync(c => c.CategoryName == name);
        }
        public int ProductCount(int categoryId)
        {
            return context.Products.Where(s => s.CategoryId == categoryId).Count();
        }
    }
}
