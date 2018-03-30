using System;
using System.Collections.Generic;
using System.Text;

namespace OS.Entities
{
    public class Store : IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StoreAddress { get; set; }
        public int StoreContactNumber { get; set; }
        public DateTime CreatedOnUTC { get; set; }
    }
}
