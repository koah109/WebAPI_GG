using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLBH.Data;
using QLBH.DTO;
using QLBH.Interface;
using QLBH.Models;
using QLBH.Models.Response;

namespace QLBH.Controllers
{
    //[AllowAnonymous]
    [Route("api/product")]
    public class HomeController : ControllerBase
    {
        private readonly IProduct Prod_service;
        private readonly IOrders Order_service;
        public HomeController(IProduct productService,IOrders Orderservice)
        {
            Prod_service = productService;
            Order_service = Orderservice;
        }

        [HttpGet]
        // api/product
        public async Task<IActionResult> GetListProducts(int id)
        {
            var prod = await Prod_service.getProd(id);
            var result = new BaseResultPagingResponse<Product>();
            result.Status = 200;
            result.Message = "Get ok";
            result.Page = 0;
            result.Total = 0;
            result.Items = prod;

            return Ok(result);

        }


        [HttpPost]
        [Route("OrderPost")]
        public async Task<IActionResult> orderProduct(OrderDTO orders)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var order = await Order_service.PostOrders(orders);
            return CreatedAtAction(nameof(GetById), new { id = order.ORDER_NO }, order);
        }

        [HttpGet]
        [Route("OrderGet")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await Order_service.GetOrderById(id);
            var result = new BaseResultPagingResponse<ORDER_DETAILS>();
            result.Status = 200;
            result.Message = "Get ok";
            result.Page = 0;
            result.Total = 0;
            result.Items = order;
            return Ok(result);
        }


        [HttpDelete]
        [Route("OrderDelete")]
        public async Task<IActionResult> deleteOrder(int id)
        {
            var result = await Order_service.DeleteOrderById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);

        }



    }
}
