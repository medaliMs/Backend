using Backend.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models.Repositories
{
    public class ProductRepository : IProductRepository
    {
        readonly ProductContext context;

        public ProductRepository(ProductContext context)
        {
            this.context = context;
        }
        public async Task<Product> AddProduct(Product product)
        {
            var result = await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Product> DeleteProduct(int id)
        {
            var result = await context.Products.FirstOrDefaultAsync(c => c.CategoryId == id);
            if (result != null)
            {
                context.Products.Remove(result);
                await context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Product> EditProduct(Product newproduct)
        {
            var result = await context.Products.FirstOrDefaultAsync(c => c.ProductId == newproduct.ProductId);
            if (result != null)
            {
                result.ProductName = newproduct.ProductName;
                result.price = newproduct.price;
                result.description = newproduct.description;
                result.MiniDescription = newproduct.MiniDescription;
                result.imageUrl = newproduct.imageUrl;
                result.IsDispo = newproduct.IsDispo;
                result.CategoryId = newproduct.CategoryId;
                await context.SaveChangesAsync();

                return result;
            }
            return null;

        }

        

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await context.Products.ToListAsync();
        }

        public async Task<Product> GetProduct(int id)
        {
            return await context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task<IEnumerable<Product>> Search(string name)
        {
            IQueryable<Product> query = context.Products;
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => p.ProductName.Contains(name));
            }
            return await query.ToListAsync();

        }

        public async Task<Product> GetByName(string name)
        {
            return await context.Products.FirstOrDefaultAsync(c => c.ProductName == name);
        }

    }
}
