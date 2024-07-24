using Microsoft.AspNetCore.Mvc;
using QLBH.DTO;
using QLBH.Interface;
using QLBH.Models.Response;
using QLBH.Models;
using Azure.Core;

namespace QLBH.Controllers
{
    [Route("api/orders")]
    public class OrdersController:ControllerBase
    {
        private readonly IOrdersService Order_service;
        public OrdersController(IOrdersService Orderservice)
        {
            Order_service = Orderservice;
        }


        [HttpPost]
        [Route("post-orders")]
        public async Task<IActionResult> OrderProduct([FromBody] OrderRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var orderd = await Order_service.PostOrders(request);
            /*var orders = new Orders
            {
                WH_CODE = 1,
                DEPT_CODE = 2,
                CUST_CODE = 3,
                CMP_TAX = 4,
                EMP_CODE = 5,
                SLIP_COMMENT = "Quá hay quá nguy hiểm",
            };
                
            return Ok(orders);*/
            return CreatedAtAction(nameof(GetById), new { id = orderd.ORDER_NO }, orderd);
            
        }

        [HttpGet]
        [Route("get-orders")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await Order_service.GetOrderById(id);
            var result = new BaseResultPagingResponse<Orders>();
            result.Status = 200;
            result.Message = "Get ok";
            result.Page = 0;
            result.Total = 0;
            result.Items = order;
            return Ok(result);
        }


        [HttpDelete]
        [Route("delete-orders")]
        public async Task<IActionResult> DeleteOrder(int id)
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
