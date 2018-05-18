using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OS.Web.ViewModels;
using OS.Services.Serivices.Abstracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OS.Web.Controllers
{
    [Route("api/[controller]")]
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            this._shoppingCartService = shoppingCartService;
        }

        [HttpGet("{id}")]
        [Route("getcartcount")]
        public IActionResult GetRemainingCartItemCountforUser(int id)

        {
            IActionResult _result = new ObjectResult(false);
            BaseResponse _productReponse = null;
            try
            {
                if (id != 0)
                {
                    var _count = this._shoppingCartService.GetCartItemCountOfUser(id);
                    _result = new ObjectResult(_count);
                }
                else
                {
                    _productReponse = new BaseResponse
                    {
                        Succeeded = false,
                        Message = "Please login to get cart item count"
                    };
                    _result = new ObjectResult(_productReponse);
                }
            }
            catch (Exception ex)
            {
                _productReponse = new BaseResponse
                {
                    Succeeded = false,
                    Message = ex.Message
                };
                _result = new ObjectResult(_productReponse);
            }
            return _result;
        }

        [HttpGet("{id}")]
        [Route("getcartdetail")]
        public IActionResult GeCartDetails(int id)

        {
            IActionResult _result = new ObjectResult(false);
            BaseResponse _productReponse = null;
            try
            {
                if (id != 0)
                {
                    var _cartdetails = this._shoppingCartService.GetCartDetails(id);
                    _result = new ObjectResult(_cartdetails);
                }
                else
                {
                    _productReponse = new BaseResponse
                    {
                        Succeeded = false,
                        Message = "Please login to get cart item details"
                    };
                    _result = new ObjectResult(_productReponse);
                }
            }
            catch (Exception ex)
            {
                _productReponse = new BaseResponse
                {
                    Succeeded = false,
                    Message = ex.Message
                };
                _result = new ObjectResult(_productReponse);
            }
            return _result;
        }


        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
