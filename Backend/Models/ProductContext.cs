using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class ProductContext : DbContext
    {


        public ProductContext(DbContextOptions<ProductContext> option) : base(option)
        {
           
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

          
        //    /*  modelBuilder.Entity<Product>()
        //          .HasOne(p => p.Category)
        //          .WithMany(b => b.Products)
        //          .IsRequired();*/


        //    modelBuilder.Entity<Category>()
        //    .HasKey(c => new { c.CategoryId });

        //    modelBuilder.Entity<Product>()
        //        .HasOne(s => s.Category)
        //        .WithMany(c => c.Products)
        //        .HasForeignKey(s => new { s.CategoryId });
        //}

    }
}
