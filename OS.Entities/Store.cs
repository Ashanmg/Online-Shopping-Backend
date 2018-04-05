using System;
using System.Collections.Generic;
using System.Text;

namespace OS.Entities
{
    public class Store : IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AddressId { get; set; }
        public int StoreContactNumber { get; set; }
        public DateTime CreatedOnUTC { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }

        public Store()
        {
            Addresses = new List<Address>();
        }
    }
}
