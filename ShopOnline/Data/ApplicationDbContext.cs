using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;
using ShopOnline.Models;

namespace ShopOnline.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Input> Inputs { get; set; }
        public DbSet<InputInfo> InputInfos { get; set; }
        public DbSet<Output> Outputs { get; set; }
        public DbSet<OutputInfo> OutputInfos { get; set; }
        public DbSet<ApplicationUsers> ApplicationUsers { get; set; }
        public DbSet<ApplicationRoles> ApplicationRoles { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Product>().ToTable("Product");
        //    modelBuilder.Entity<Category>().ToTable("Category");
        //    modelBuilder.Entity<Supplier>().ToTable("Supplier");
        //    modelBuilder.Entity<Customer>().ToTable("Customer");
        //    modelBuilder.Entity<Input>().ToTable("Input");
        //    modelBuilder.Entity<InputInfo>().ToTable("InputInfo");
        //    modelBuilder.Entity<Output>().ToTable("Output");
        //    modelBuilder.Entity<OutputInfo>().ToTable("OutputInfo");

        //}
    }
}
