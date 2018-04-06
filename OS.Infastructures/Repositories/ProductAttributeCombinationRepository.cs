using OS.Entities;
using OS.Infastructures.Core;
using OS.Infastructures.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OS.Infastructures.Repositories
{
    public class ProductAttributeCombinationRepository : EntityBaseRepository<ProductAttributeCombination>, IProductAttributeCombinationRepository
    {
        public ProductAttributeCombinationRepository(OnlineShoppingDbContext context) : base(context)
        {

        }
    }
}
