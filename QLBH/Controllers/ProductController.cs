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
        private readonly IProductService Product_Service;
        public ProductController(IProductService productService)
        {
            Product_Service = productService;
        }

        //todo api search sản phẩm theo tên 
        [HttpGet]
        [Route("get-product-byname")]
        public IActionResult SearchProdByName(ProductRequest request)
        {
            var prod = Product_Service.GetProdByName(request);
            var result = new BaseResultPagingResponse<Product>();
            result.Status = 200;
            result.Message = "Get ok";
            result.Page = 0;
            result.Total = 0;
            result.Items = prod.Result;
            return Ok(result);
        }

        [HttpGet]
        [Route("get-id-product")]

        public async Task<IActionResult> GetById(int id)
        {
            var order = await Product_Service.GetProd(id);
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
            var product = await Product_Service.PostProdById(products);
            return CreatedAtAction(nameof(GetById), new { id = product.PROD_CODE }, product); //nameof(Lấy hàm get từ service)
        }


        [HttpPut]
        [Route("update-product")]
        public async Task<IActionResult> PutProd([FromBody] Product request)
        {
            var product = await Product_Service.PutProductById(request);
            return Ok(product);
        }


        [HttpDelete]
        [Route("delete-product")]
        public async Task<IActionResult> DeleteProd(int id)
        {
            var product = await Product_Service.DeleteProductById(id);
            return Ok(product);
        }
    }
}
