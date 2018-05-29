using OS.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OS.Services.Serivices.Abstracts
{
    public interface IProductService
    {
        // Retrun type list use for the pupose of add , remove etc...
        // Return type a enumerable interface use for the pupose of read only etc...
        Task<IEnumerable<Product>> GetProductListForProductType(int productTypeId);
        List<Product> GetProductListForCategoryPage();
        Task<Product> GetSingleProduct(int id);
        IEnumerable<ProductType> GetProductTypes();
        Boolean IsVariantProduct(int productId);
        List<ProductAttributeValue> GetProductAttributeValue(int id);
    }
}
