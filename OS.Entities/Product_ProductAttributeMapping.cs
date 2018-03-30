using System;
using System.Collections.Generic;
using System.Text;

namespace OS.Entities
{
    public class Product_ProductAttributeMapping : IEntityBase
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ProductAttributeId { get; set; }
        public int IsRequired { get; set; }
        public virtual Product Product { get; set; }
        public virtual ProductAttribute ProductAttribute { get; set; }
    }
}
