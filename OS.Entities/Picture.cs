using System;
using System.Collections.Generic;
using System.Text;

namespace OS.Entities
{
    public class Picture : IEntityBase
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ProductTypeId { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreatedOnUTC { get; set; }
        public DateTime UpdatedOnUTC { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<ProductType> ProductTypes { get; set; }
        public Picture()
        {
            Products = new List<Product>();
            ProductTypes = new List<ProductType>();
        }
    }
}
