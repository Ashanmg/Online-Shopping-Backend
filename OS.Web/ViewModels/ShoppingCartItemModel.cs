using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OS.Web.ViewModels
{
    public class ShoppingCartItemModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ColourId { get; set; }
        public int SizeId { get; set; }
        public int ProductId { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        public int StoreId { get; set; }
        public int ShoppingCartTypeId { get; set; }
    }
}
