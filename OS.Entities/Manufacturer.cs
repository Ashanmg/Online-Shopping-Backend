using System;
using System.Collections.Generic;
using System.Text;

namespace OS.Entities
{
    public class Manufacturer : IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOnUTC { get; set; }
        public DateTime UpdatedOnUTC { get; set; }
    }
}
