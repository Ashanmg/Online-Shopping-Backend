using System;
using System.Collections.Generic;
using System.Text;

namespace OS.Entities
{
    public class OrderNote : IEntityBase
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string Note { get; set; }
        public int DisplayToCustomer { get; set; }
        public DateTime CreatedOnUTC { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public OrderNote()
        {
            Orders = new List<Order>();
        }
    }
}
