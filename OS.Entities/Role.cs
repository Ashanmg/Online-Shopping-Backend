using System;
using System.Collections.Generic;
using System.Text;

namespace OS.Entities
{
    public class Role :IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SystemName { get; set; }
        public int Active { get; set; }
        public int FreeShipping { get; set; }
        public int TaxEnabled { get; set; }
    }
}
