using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OS.Web.ViewModels;
using OS.Services.Serivices.Abstracts;
using AutoMapper;
using OS.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OS.Web.Controllers
{
    [Route("api/[controller]")]
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IMapper _mapper;

        public ShoppingCartController(
            IShoppingCartService shoppingCartService,
            IMapper mapper)
        {
            this._shoppingCartService = shoppingCartService;
            this._mapper = mapper;
        }

        [HttpGet("{id}")]
        [Route("getcartcount")]
        public IActionResult GetRemainingCartItemCountforUser(int id)

        {
            IActionResult _result = new ObjectResult(false);
            BaseResponse _carttReponse = null;
            try
            {
                if (id != 0)
                {
                    var _count = this._shoppingCartService.GetCartItemCountOfUser(id);
                    _result = new ObjectResult(_count);
                }
                else
                {
                    _carttReponse = new BaseResponse
                    {
                        Succeeded = false,
                        Message = "Please login to get cart item count"
                    };
                    _result = new ObjectResult(_carttReponse);
                }
            }
            catch (Exception ex)
            {
                _carttReponse = new BaseResponse
                {
                    Succeeded = false,
                    Message = ex.Message
                };
                _result = new ObjectResult(_carttReponse);
            }
            return _result;
        }

        [HttpGet("{id}")]
        [Route("getcartdetail")]
        public IActionResult GeCartDetails(int id)

        {
            IActionResult _result = new ObjectResult(false);
            BaseResponse _carttReponse = null;
            try
            {
                if (id != 0)
                {
                    var _cartdetails = this._shoppingCartService.GetCartDetails(id);
                    _result = new ObjectResult(_cartdetails);
                }
                else
                {
                    _carttReponse = new BaseResponse
                    {
                        Succeeded = false,
                        Message = "Please login to get cart item details"
                    };
                    _result = new ObjectResult(_carttReponse);
                }
            }
            catch (Exception ex)
            {
                _carttReponse = new BaseResponse
                {
                    Succeeded = false,
                    Message = ex.Message
                };
                _result = new ObjectResult(_carttReponse);
            }
            return _result;
        }


        // POST api/values
        [HttpPost]
        [Route("addcartdetail")]
        public IActionResult AddCartDetails([FromBody]ShoppingCartItemModel cartItem)
        {
            IActionResult _result = new ObjectResult(false);
            BaseResponse _cartResponse = null;

            try
            {
                if (cartItem.UserId != 0)
                {
                    // Mapping to ShoppingCartItem entity
                    var shoppingCartItem = _mapper.Map<ShoppingCartItemModel, ShoppingCartItem>(cartItem);
                    var cartdetails = _shoppingCartService.AddCartDetails(shoppingCartItem);

                    _result = new ObjectResult(cartdetails);
                }
                else
                {
                    _cartResponse = new BaseResponse
                    {
                        Succeeded = false,
                        Message = "Please login to add cart item details"
                    };
                    _result = new ObjectResult(_cartResponse);
                }
            }
            catch (Exception ex)
            {
                _cartResponse = new BaseResponse
                {
                    Succeeded = true,
                    Message = ex.Message
                };
                _result = new ObjectResult(_cartResponse);
            }

            return _result;
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
