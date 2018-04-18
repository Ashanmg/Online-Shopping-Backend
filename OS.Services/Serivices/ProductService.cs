using OS.Entities;
using OS.Infastructures.Repositories.Abstracts;
using OS.Services.Serivices.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OS.Services.Serivices
{
    public class ProductService : IProductService
    {
        #region fields
        private readonly IProductRepository _productRepository;
        #endregion

        #region constructor
        public ProductService(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }
        #endregion

        #region Methods
        public IEnumerable<Product> GetProductListForProductType(int productTypeId)
        {
            var _product = _productRepository.FindBy(p => p.ProductTypeId == productTypeId);
            return _product;
        }

        public Task<IEnumerable<Product>> GetProductListForCategoryPage()
        {
            return _productRepository.FindByAsync(p => p.ShowOnCategoryPage == 1);
        }

        public Product GetSingleProduct(int id)
        {
            return _productRepository.GetSingle(id);
        }
        #endregion 
    }
}
