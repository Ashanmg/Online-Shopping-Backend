using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OS.Services.Serivices.Abstracts;
using OS.Web.ViewModels;
using OS.Entities;

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
        [Route("products")]
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

                // create object list set
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
        [Route("category")]
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
                // get product types
                var _productTypeList = GetProductTypes();

                var _productList = _productService.GetProductListForCategoryPage();

                var _objectResponse = new ObjectResponse
                {
                    ParentList = _productTypeList,
                    productList = _productList
                };
                _result = new ObjectResult(_objectResponse);
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
        [Route("singleproduct")]
        ///<summary>
        ///
        /// </summary>
        /// <returns></returns>
        public IActionResult GetSingleProduct(int id)
        {
            IActionResult _result = new ObjectResult(false);
            ProductResponse _productResponse = null;
            try
            {
                var _product = _productService.GetSingleProduct(id).Result;
                var productAttribute = _productService.GetProductAttributeValue(id);

                _productResponse = new ProductResponse
                {
                    Succeeded = true,
                    // Message = "Successfully variant type selected"
                    SingleProduct = _product,
                    AttributeValue = productAttribute
                };
                _result = new ObjectResult(_productResponse);
            }
            catch (Exception ex)
            {
                _productResponse = new ProductResponse
                {
                    Succeeded = false,
                    Message = ex.Message
                };
                _result = new ObjectResult(_productResponse);
            }

            return _result;
        }
        #endregion

        [HttpGet("productId")]
        [Route("checkvariant")]
        ///<summary>
        ///
        /// </summary>
        /// <returns></returns>
        public IActionResult IsVariantProduct(int productId)
        {
            IActionResult _result = new ObjectResult(false);
            BaseResponse _productResponse = null;
            try
            {
                var isVariantProduct = _productService.IsVariantProduct(productId);
                _result = new ObjectResult(isVariantProduct);
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

        #region helperMethod

        /// <summary>
        /// Get all product types
        /// </summary>
        /// <returns></returns>
        private List<ParentProductTypeModel> GetProductTypes()
        {
            var _productTypeList = _productService.GetProductTypes();
            var _parentProductTypeList = _productTypeList.Where(x => x.PerentProductTypeId == 0);
            _productTypeList = _productTypeList.Where(x => x.PerentProductTypeId != 0);

            var _parentList = new List<ParentProductTypeModel>();

            foreach (var productType in _parentProductTypeList)
            {
                var _parentProductType = new ParentProductTypeModel
                {
                    Id = productType.Id,
                    Name = productType.Name
                };

                _parentList.Add(_parentProductType);
            }

            foreach (var productType in _productTypeList)
            {
                var _index = _parentList.FindIndex(x => x.Id == productType.PerentProductTypeId);
                var _parentProductType = new ChildProductTypeModel
                {
                    Id = productType.Id,
                    Name = productType.Name
                };

                // _parentList.Where(x => { x.ChildProductTypeList.Add(_parentProductType)})

                _parentList[_index].ChildProductTypeList.Add(_parentProductType);            
            }

            return _parentList;
        }
        #endregion
    }
}
