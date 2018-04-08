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
        public virtual AccountUser AccountUser { get; set; }
        public virtual Product Product { get; set; }

        public ProductReview()
        {
        }
    }
}
