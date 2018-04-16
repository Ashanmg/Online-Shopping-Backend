using OS.Entities;
using OS.Infastructures.Repositories.Abstracts;
using OS.Services.Serivices.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OS.Services.Serivices
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public IEnumerable<Product> GetProductListForProductType(int productTypeId)
        {
            var _product = _productRepository.FindBy(p => p.ProductTypeId == productTypeId);
            return _product;
        }
    }
}
