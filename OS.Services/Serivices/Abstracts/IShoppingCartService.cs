using System;
using System.Collections.Generic;
using System.Text;

namespace OS.Services.Serivices.Abstracts
{
    public interface IShoppingCartService
    {
        int GetCartItemCountOfUser(int id);
    }
}
