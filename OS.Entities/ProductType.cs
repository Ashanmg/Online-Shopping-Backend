using System;
using System.Collections.Generic;
using System.Text;

namespace OS.Entities
{
    public class ProductType : IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PerentProductTypeId { get; set; }
        public int Active { get; set; }
        public DateTime UpdatedOnUTC { get; set; }
    }
}
