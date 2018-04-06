using OS.Entities;
using OS.Infastructures.Core;
using OS.Infastructures.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OS.Infastructures.Repositories
{
    public class StockItemMappingRepository : EntityBaseRepository<StockItemMapping>, IStockItemMappingRepository
    {
        public StockItemMappingRepository(OnlineShoppingDbContext context) : base(context)
        {

        }
    }
}
