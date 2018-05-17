using OS.Entities;
using OS.Infastructures.Core;
using OS.Infastructures.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OS.Infastructures.Repositories
{
    public class ShoppingCartItemRepository : EntityBaseRepository<ShoppingCartItem>, IShoppingCartItemRepository
    {
        private readonly OnlineShoppingDbContext _context;

        public ShoppingCartItemRepository(OnlineShoppingDbContext context) : base(context)
        {
            this._context = context;
        }

        public int GetCartItemCountOfUser(int accountUserId)
        {
            return _context.ShoppingCartItem.Where(x => x.AccountUserId == accountUserId).Count();
        }
    }
}
