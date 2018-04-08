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
        public DbSet<Address> Address { get; set; }
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

            //Account User
            modelBuilder.Entity<AccountUser>().Property(p => p.Id).IsRequired();
            modelBuilder.Entity<AccountUser>().Property(p => p.FirstName).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<AccountUser>().Property(p => p.LastName).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<AccountUser>().Property(p => p.EmailAddress).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<AccountUser>().Property(p => p.Username).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<AccountUser>().Property(p => p.HashedPassword).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<AccountUser>().Property(p => p.PasswordSalt).IsRequired().HasMaxLength(15);
            modelBuilder.Entity<AccountUser>().Property(p => p.ContactNumber).HasMaxLength(10);

            //Account User Role
            modelBuilder.Entity<AccountUserRole>().Property(p => p.Id).IsRequired();

            //Address
            modelBuilder.Entity<Address>().Property(p => p.Id).IsRequired();
            modelBuilder.Entity<Address>().Property(p => p.Address1).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Address>().Property(p => p.Address2).HasMaxLength(200);
            modelBuilder.Entity<Address>().Property(p => p.City).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Address>().Property(p => p.ZipPostalCode).IsRequired().HasMaxLength(20);

            // Manufacturer
            modelBuilder.Entity<Manufacturer>().Property(p => p.Id).IsRequired();
            modelBuilder.Entity<Manufacturer>().Property(p => p.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Manufacturer>().Property(p => p.Description).HasMaxLength(300);

            // Order
            modelBuilder.Entity<Order>().Property(p => p.Id).IsRequired();

            // OrderItem

            // OrderNote
            modelBuilder.Entity<OrderNote>().Property(p => p.Note).HasMaxLength(50);

            // Picture

            // Product
            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Product>().Property(p => p.ShortDescription).HasMaxLength(150);

            // Product_ProductAttributeMapping

            // ProductAttribute
            modelBuilder.Entity<ProductAttribute>().Property(p => p.Name).HasMaxLength(50);
            modelBuilder.Entity<ProductAttribute>().Property(p => p.Description).HasMaxLength(150);

            // ProductAttributeCombination
            modelBuilder.Entity<ProductAttributeCombination>().Property(p => p.AttributeXml).HasMaxLength(int.MaxValue);

            // ProductReview
            modelBuilder.Entity<ProductReview>().Property(p => p.ReviewText).HasMaxLength(300);

            // ProductType
            modelBuilder.Entity<ProductType>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<ProductType>().Property(p => p.Description).HasMaxLength(200);

            // Role
            modelBuilder.Entity<Role>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Role>().Property(p => p.SystemName).HasMaxLength(100);

            // Shopping Cart Item
            modelBuilder.Entity<ShoppingCartItem>().Property(p => p.AttributeXml).HasMaxLength(int.MaxValue);

            // StockMapping

            // Store
            modelBuilder.Entity<Store>().Property(p => p.Name).IsRequired().HasMaxLength(50);
        }
    }
}
