using System;
using System.Collections.Generic;
using System.Text;

namespace OS.Entities
{
    public class OrderItem : IEntityBase
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quentity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal SubTotalPrice { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }

        public OrderItem()
        {
        }
    }
}
