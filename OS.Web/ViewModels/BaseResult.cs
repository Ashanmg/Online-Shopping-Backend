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
}
