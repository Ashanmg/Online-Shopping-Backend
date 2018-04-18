using OS.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OS.Services.Serivices.Abstracts
{
    public interface IProductService
    {
        IEnumerable<Product> GetProductListForProductType(int productTypeId);
        Task<IEnumerable<Product>> GetProductListForCategoryPage();
        Product GetSingleProduct(int id);
    }
}
