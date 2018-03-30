using System;
using System.Collections.Generic;
using System.Text;

namespace OS.Entities
{
    public class ShoppingCartItem : IEntityBase
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public int ShoppingCartTypeId { get; set; }
        public int AccountUserId { get; set; }
        public int ProductId { get; set; }
        public string AttributeXml { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quentity { get; set; }
        public DateTime CreatedOnUTC { get; set; }
        public DateTime UpdatedOnUTC { get; set; }

        public virtual ICollection<Store> Stores { get; set; }
        public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
        public virtual ICollection<AccountUser> Users { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public ShoppingCartItem()
        {
            Stores = new List<Store>();
            ShoppingCartItems = new List<ShoppingCartItem>();
            Users = new List<AccountUser>();
            Products = new List<Product>();
        }
    }
}
