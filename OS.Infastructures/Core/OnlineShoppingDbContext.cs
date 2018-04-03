using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OS.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OS.Infastructures.Core
{
    public class OnlineShoppingDbContext : DbContext
    {
        public DbSet<AccountUser> AccountUser { get; set; }
        public DbSet<AccountUserRole> AccountUserRole { get; set; }
        public DbSet<Address> Addresse { get; set; }
        public DbSet<Manufacturer> Manufacturer { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<OrderNote> OrderNote { get; set; }
        public DbSet<Picture> Picture { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Product_ProductAttributeMapping> Product_ProductAttributeMapping { get; set; }
        public DbSet<ProductAttribute> ProductAttribute { get; set; }
        public DbSet<ProductAttributeCombination> ProductAttributeCombination { get; set; }
        public DbSet<ProductReview> ProductReview { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItem { get; set; }
        public DbSet<StockItemMapping> StockItemMapping { get; set; }
        public DbSet<Store> Store { get; set; }

        public OnlineShoppingDbContext(DbContextOptions<OnlineShoppingDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.Relational().TableName = entity.DisplayName();
            }

            // add other required conditions to Entites
        }
    }
}
