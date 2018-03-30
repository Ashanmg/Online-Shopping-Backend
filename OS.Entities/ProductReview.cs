using System;
using System.Collections.Generic;
using System.Text;

namespace OS.Entities
{
    public class ProductReview : IEntityBase
    {
        public int Id { get; set; }
        public int AccountUserId { get; set; }
        public int ProductId { get; set; }
        public int IsApproved { get; set; }
        public string ReviewText { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedOnUTC { get; set; }
        public virtual ICollection<AccountUser> Users { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public ProductReview()
        {
            Users = new List<AccountUser>();
            Products = new List<Product>();
        }
    }
}
