using System;
using System.Collections.Generic;
using System.Text;

namespace OS.Entities
{
    public class ProductAttributeCombination : IEntityBase
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string AttributeXml { get; set; }
        public int AvailableQuentity { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public ProductAttributeCombination()
        {
            Products = new List<Product>();
        }
    }
}
