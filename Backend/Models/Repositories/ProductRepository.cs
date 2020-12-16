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
        public void Add(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void Delete(Product product)
        {
            Product p1 = context.Products.Find(product.ProductId);
            if (p1 != null)
            {
                context.Products.Remove(p1);
                context.SaveChanges();
            }
        }

        public void Edit(Product newproduct)
        {
            Product oldstudent = context.Products.Find(newproduct.ProductId);
            if (oldstudent != null)
            {
                oldstudent.ProductName = newproduct.ProductName;
                oldstudent.price = newproduct.price;
                oldstudent.description = newproduct.description;
                oldstudent.MiniDescription = newproduct.MiniDescription;
                oldstudent.imageUrl = newproduct.imageUrl;
                oldstudent.IsDispo = newproduct.IsDispo;
                oldstudent.CategoryId = newproduct.CategoryId;
                context.SaveChanges();
            }

        }

        public IList<Product> FindByName(string name)
        {
            return context.Products.Where(s => s.ProductName.Contains(name)).Include(std => std.Category).ToList();
        }

        public IList<Product> GetAll()
        {
            return context.Products.OrderBy(x => x.ProductName).Include(x => x.Category).ToList();
        }

        public Product GetById(int id)
        {
            return context.Products.Where(x => x.ProductId == id).Include(x => x.Category).SingleOrDefault();
        }

        public IList<Product> GetProductsByCategoryID(int? categoryId)
        {
            return context.Products.Where(s => s.CategoryId.Equals(categoryId))
                .OrderBy(s => s.ProductName)
                .Include(std => std.Category).ToList();
        }
    }
}
