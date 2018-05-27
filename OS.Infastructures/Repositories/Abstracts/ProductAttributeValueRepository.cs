using OS.Entities;
using OS.Infastructures.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OS.Infastructures.Repositories.Abstracts
{
    public class ProductAttributeValueRepository : EntityBaseRepository<ProductAttributeValue>, IProductAttributeValueRepository
    {
        public ProductAttributeValueRepository(OnlineShoppingDbContext context) : base(context)
        {

        }
    }
}
