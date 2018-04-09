using OS.Entities;
using OS.Infastructures.Core;
using OS.Infastructures.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OS.Infastructures.Repositories
{
    public class AddressRepository : EntityBaseRepository<Address>, IAddressRepository
    {
        private readonly OnlineShoppingDbContext _context;

        public AddressRepository(OnlineShoppingDbContext context) : base(context)
        {
            this._context = context;
        }

        public Address GetInsertedAddress()
        {
            return _context.Address.OrderByDescending(a => a.Id).FirstOrDefault();
        }
    }
}
