using System;
using System.Collections.Generic;
using System.Text;

namespace OS.Entities
{
    public class ProductAttributeValue : IEntityBase
    {
        public int Id { get; set; }
        public int ProductAttributeId { get; set; }
        public string ProductValue { get; set; }
        public string ValueDescription { get; set; }
        public DateTime CreatedOnUTC { get; set; }

        public virtual ProductAttribute ProductAttribute { get; set; }

        public ProductAttributeValue()
        {

        }
    }
}
