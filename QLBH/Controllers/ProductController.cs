using Microsoft.AspNetCore.Mvc;
using QLBH.DTO;
using QLBH.Models.Response;
using QLBH.Models;
using QLBH.Interface;

namespace QLBH.Controllers
{
    [Route("api/product")]
    public class ProductController: ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        //todo api search sản phẩm theo tên 
        [HttpGet]
        [Route("get-product-byname")]
        public IActionResult SearchProdByName(ProductRequest request)
        {
            var prod = _productService.GetProdByName(request);
            var result = new BaseResultPagingResponse<Product>();
            result.Status = 200;
            result.Message = "Get ok";
            result.Page = 0;
            result.Total = 0;
            result.Items = prod.Result;
            return Ok(result);
        }

        [HttpGet]
        [Route("get-list-product")]

        public async Task<IActionResult> GetById()
        {
            var order = await _productService.GetProd();
            var result = new BaseResultPagingResponse<Product>();
            result.Status = 200;
            result.Message = "Get ok";
            result.Page = 0;
            result.Total = 0;
            result.Items = order;
            return Ok(result);
        }

        [HttpPost]
        [Route("post-product")]
        public async Task<IActionResult> PostProd([FromBody] ProductRequest products)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var product = await _productService.PostProdById(products);
            return Ok(product);
        }


        [HttpPut]
        [Route("update-product")]
        public async Task<IActionResult> PutProd(Product request)
        {
            var product = await _productService.PutProductById(request);
            return Ok(product);
        }


        [HttpDelete]
        [Route("delete-product")]
        public async Task<IActionResult> DeleteProd(int id)
        {
            var product = await _productService.DeleteProductById(id);
            return Ok(product);
        }
    }
}
