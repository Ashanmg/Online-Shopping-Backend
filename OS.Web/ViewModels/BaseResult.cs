using OS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OS.Web.ViewModels
{
    public class BaseResponse
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
    }

    public class ObjectResponse
    {
        public List<ParentProductTypeModel> ParentList { get; set; }
        public List<Product> productList { get; set; }

        public ObjectResponse()
        {
            ParentList = new List<ParentProductTypeModel>();
            productList = new List<Product>();
        }
    }

    public class ProductResponse : BaseResponse
    {
        public Product SingleProduct { get; set; }
        public List<ProductAttributeValue> AttributeValue{ get; set; }

        public ProductResponse()
        {
            AttributeValue = new List<ProductAttributeValue>();
        }
    }
}
