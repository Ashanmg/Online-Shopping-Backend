using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OS.Services.Serivices.Abstracts;
using OS.Web.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OS.Web.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        #region fields
        private readonly IProductService _productService;
        #endregion

        #region constructor
        public ProductController(
            IProductService productService)
        {
            this._productService = productService;
        }
        #endregion

        #region API Methods
        [HttpGet("cId")]
        [Route("/products")]
        /// <summary>
        /// get all product for specific selected product type
        /// </summary>
        /// <param name="cId">the product type id</param>
        /// <returns>returns product list</returns>
        public IActionResult GetAllProductForProductType(int cId)
        {
            IActionResult _result = new ObjectResult(false);
            BaseResponse _productResponse = null;
            try
            {
                var _productList = _productService.GetProductListForProductType(cId);
                _result = new ObjectResult(_productList);
            }
            catch (Exception ex)
            {
                _productResponse = new BaseResponse
                {
                    Succeeded = false,
                    Message = ex.Message
                };
                _result = new ObjectResult(_productResponse);
            }

            return _result;
        }

        [HttpGet]
        [Route("/category")]
        /// <summary>
        /// get product for category home page what products set to home category page.
        /// </summary>
        /// <returns></returns>
        public IActionResult GetProductForCategoryPage()
        {
            IActionResult _result = new ObjectResult(false);
            BaseResponse _productResponse = null;
            try
            {
                var _productList = _productService.GetProductListForCategoryPage();
                _result = new ObjectResult(_productList);
            }
            catch (Exception ex)
            {
                _productResponse = new BaseResponse
                {
                    Succeeded = false,
                    Message = ex.Message
                };
                _result = new ObjectResult(_productResponse);
            }

            return _result;
        }

        [HttpGet("id")]
        [Route("/singleproduct")]
        public IActionResult GetSingleProduct(int id)
        {
            IActionResult _result = new ObjectResult(false);
            BaseResponse _productResponse = null;
            try
            {
                var _product = _productService.GetSingleProduct(id);
                _result = new ObjectResult(_product);
            }
            catch (Exception ex)
            {
                _productResponse = new BaseResponse
                {
                    Succeeded = false,
                    Message = ex.Message
                };
                _result = new ObjectResult(_productResponse);
            }

            return _result;
        }
        #endregion
    }
}
