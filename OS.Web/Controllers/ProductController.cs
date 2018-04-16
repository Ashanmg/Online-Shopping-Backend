using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OS.Web.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        [HttpGet("cId")]
        [Route("/products")]
        public IActionResult GetAllProduct(int cId)
        {
            IActionResult _result = new ObjectResult(false);
            
            try
            {

            }
            catch (Exception ex)
            {

            }

            return _result;
        }
    }
}
