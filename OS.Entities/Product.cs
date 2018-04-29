using System;
using System.Collections.Generic;
using System.Text;

namespace OS.Entities
{
    public class Product : IEntityBase
    {
        public int Id { get; set; }
        public int ProductTypeId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public int ShowOnCategoryPage { get; set; }
        public int AllowCustomerReview { get; set; }
        public int ApprovedTotalReview { get; set; }
        public decimal ApprovedRatingSum { get; set; }
        public int ManufacturerId { get; set; }
        public int PictureId { get; set; }
        public decimal Price { get; set; }
        public int TaxIncluded { get; set; }
        public DateTime CreatedOnUTC { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual ProductType ProductType { get; set; }
        public virtual Picture Picture { get; set; }

        public Product()
        {
        }
    }
}
