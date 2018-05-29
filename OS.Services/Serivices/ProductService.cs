using OS.Entities;
using OS.Infastructures.Repositories.Abstracts;
using OS.Services.Serivices.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Services.Serivices
{
    public class ProductService : IProductService
    {
        #region fields
        private readonly IProductRepository _productRepository;
        private readonly IProductTypeRepository _productTypeRepository;
        private readonly IProduct_ProductAttributeMappingRepository _product_ProductAttributeMappingRepository;
        private readonly IProductAttributeValueRepository _productAttributeValueRepository;
        #endregion

        #region constructor
        public ProductService(IProductRepository productRepository,
            IProductTypeRepository productTypeRepository,
            IProduct_ProductAttributeMappingRepository product_ProductAttributeMappingRepository,
            IProductAttributeValueRepository productAttributeValueRepository)
        {
            this._productRepository = productRepository;
            this._productTypeRepository = productTypeRepository;
            this._product_ProductAttributeMappingRepository = product_ProductAttributeMappingRepository;
            this._productAttributeValueRepository = productAttributeValueRepository;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Get products for selected product type
        /// </summary>
        /// <param name="productTypeId">The product type id</param>
        /// <returns>Return a list of products</returns>
        public Task<IEnumerable<Product>> GetProductListForProductType(int productTypeId)
        {
            var _product = _productRepository.FindByAsync(p => p.ProductTypeId == productTypeId);
            return _product;
        }

        /// <summary>
        /// Get products for category homepage to show before select product type
        /// </summary>
        /// <returns>Retrun a list of product</returns>
        public List<Product> GetProductListForCategoryPage()
        {
            return _productRepository.GetProductListForCategoryPage();
        }

        /// <summary>
        /// Get a single product
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>Retrun a single product</returns>
        public Task<Product> GetSingleProduct(int id)
        {
            return _productRepository.GetSingleAsync(id);
        }

        public IEnumerable<ProductType> GetProductTypes()
        {
            return _productTypeRepository.GetAll();
        }

        public bool IsVariantProduct(int productId)
        {
            var value = _product_ProductAttributeMappingRepository.FindBy(p => p.ProductId == productId).ToList();
            if (value.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<ProductAttributeValue> GetProductAttributeValue(int productId)
        {
            return _productAttributeValueRepository.GetProductAttributeValues(productId);
        }
    }   
        #endregion 
}
