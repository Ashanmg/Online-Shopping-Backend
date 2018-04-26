using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OS.Web.ViewModels
{
    public class ParentProductTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsOpen { get; set; }
        public List<ChildProductTypeModel> ChildProductTypeList { get; set; }

        public ParentProductTypeModel()
        {
            ChildProductTypeList = new List<ChildProductTypeModel>();
        }
    }

    public class ChildProductTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
