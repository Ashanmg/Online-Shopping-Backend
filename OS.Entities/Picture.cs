using System;
using System.Collections.Generic;
using System.Text;

namespace OS.Entities
{
    public class Picture : IEntityBase
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreatedOnUTC { get; set; }
        public DateTime UpdatedOnUTC { get; set; }
        public Picture()
        {
        }
    }
}
