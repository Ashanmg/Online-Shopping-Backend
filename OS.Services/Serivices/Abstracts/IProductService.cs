using OS.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OS.Services.Serivices.Abstracts
{
    public interface IProductService
    {
        IEnumerable<Product> GetProductListForProductType(int productTypeId);
    }
}
