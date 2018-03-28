using System;
using System.Collections.Generic;
using System.Text;

namespace OS.Entities
{
    public class Address : IEntityBase
    {
        public int Id { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public int ZipPostalCode { get; set; }
        public int CountryId { get; set; }
        public DateTime ModifiedOnUTC { get; set; }
    }
}
