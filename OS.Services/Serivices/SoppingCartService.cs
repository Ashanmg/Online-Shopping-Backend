using OS.Entities;
using OS.Infastructures.Repositories.Abstracts;
using OS.Services.Serivices.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OS.Services.Serivices
{
    public class SoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartItemRepository _shoppingCartItemRepository;

        public SoppingCartService(IShoppingCartItemRepository shoppingCartItemRepository)
        {
            this._shoppingCartItemRepository = shoppingCartItemRepository;
        }
        public int GetCartItemCountOfUser(int id)
        {
            return _shoppingCartItemRepository.GetCartItemCountOfUser(id);
        }

        public List<ShoppingCartItem> GetCartDetails(int id)
        {
            return _shoppingCartItemRepository.FindBy(x => x.AccountUserId == id).Cast<ShoppingCartItem>().ToList();
        }
    }
}
