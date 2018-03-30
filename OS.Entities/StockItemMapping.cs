using System;
using System.Collections.Generic;
using System.Text;

namespace OS.Entities
{
    public class StockItemMapping : IEntityBase
    {
        public int Id { get; set; }
        public int AttributeCombinationId { get; set; }
        public int StoreId { get; set; }
        public virtual ProductAttributeCombination AttributeCombination { get; set; }
        public virtual Store Store { get; set; }
    }
}
