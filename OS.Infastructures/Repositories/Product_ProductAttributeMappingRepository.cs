using OS.Entities;
using OS.Infastructures.Core;
using OS.Infastructures.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OS.Infastructures.Repositories
{
    public class Product_ProductAttributeMappingRepository : EntityBaseRepository<Product_ProductAttributeMapping>, IProduct_ProductAttributeMappingRepository
    {
        public Product_ProductAttributeMappingRepository(OnlineShoppingDbContext context) : base(context)
        {

        }
    }
}
