using OS.Entities;
using OS.Infastructures.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OS.Infastructures.Repositories.Abstracts
{
    public class ProductAttributeValueRepository : EntityBaseRepository<ProductAttributeValue>, IProductAttributeValueRepository
    {
        private readonly OnlineShoppingDbContext _context;
        private readonly IProduct_ProductAttributeMappingRepository _product_ProductAttributeMappingRepository;

        public ProductAttributeValueRepository(
            OnlineShoppingDbContext context,
            IProduct_ProductAttributeMappingRepository product_ProductAttributeMappingRepository) : base(context)
        {
            this._context = context;
            this._product_ProductAttributeMappingRepository = product_ProductAttributeMappingRepository;
        }

        public List<ProductAttributeValue> GetProductAttributeValues(int productId)
        {
            var variantAttribute = _product_ProductAttributeMappingRepository.FindBy(p => p.ProductId == productId).Select(p => p.ProductAttributeId).ToList();
            return _context.ProductAttributeValue.Where(p => variantAttribute.Contains(p.ProductAttributeId)).ToList();
        }
    }
}
