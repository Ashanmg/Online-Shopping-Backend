using OS.Entities;
using OS.Infastructures.Core;
using OS.Infastructures.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace OS.Infastructures.Repositories
{
    public class ProductRepository : EntityBaseRepository<Product>, IProductRepository
    {
        private readonly OnlineShoppingDbContext _context;

        public ProductRepository(OnlineShoppingDbContext context) : base(context)
        {
            this._context = context;
        }
        public List<Product> GetProductListForCategoryPage()
        {
            return _context.Product.Where(x => x.ShowOnCategoryPage == 1)
                .Select(x => new Product
                {
                    Id = x.Id,
                    Name = x.Name,
                    ShortDescription = x.ShortDescription,
                    Price = x.Price,
                    PictureId = x.PictureId
                }).ToList();
        }
    }
}
