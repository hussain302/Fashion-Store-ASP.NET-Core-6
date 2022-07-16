using FashionStore.Data.Products;
using FashionStore.Data.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionStore.Data
{
    public class FashionContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Product> Products { get; set; }

        //public DbSet<CartItem> CartItems { get; set; }
        //public DbSet<Cart> Carts { get; set; }

        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Order> Orders { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies()
                .UseSqlServer("Data Source=HUSSAIN\\HACK3R;Initial Catalog=FashionStoreDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<ProductCategory>()
                        .HasMany<Product>(g => g.Products)
                        .WithOne(c => c.ProductCategory).HasForeignKey(c => c.CategoryId)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductType>()
                        .HasMany<Product>(g => g.Products)
                        .WithOne(c => c.ProductType).HasForeignKey(c => c.TypeId)
                        .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
