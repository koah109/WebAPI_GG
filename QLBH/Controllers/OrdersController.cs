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
        private readonly IOrdersService _orderService;
        public OrdersController(IOrdersService Orderservice)
        {
            _orderService = Orderservice;
        }


        [HttpPost]
        [Route("post-orders")]
        public async Task<IActionResult> OrderProduct([FromBody] OrderRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var orderd = await _orderService.PostOrders(request);
            return Ok("Đặt hàng thành công");
            
        }

        [HttpGet]
        [Route("get-orders")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _orderService.GetOrderById(id);
            var result = new BaseResultPagingResponse<Orders>();
            result.Status = 200;
            result.Message = "Get ok";
            result.Page = 0;
            result.Total = 0;
            result.Items = order;
            return Ok(result);
        }


        [HttpGet]
        [Route("get-detail-orders/{id}")]
        public async Task<IActionResult> GetOrderDetail(int id)
        {
            var order = await _orderService.GetDetailOrder(id);
            return Ok(order);
        }


        [HttpDelete]
        [Route("delete-orders")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var result = await _orderService.DeleteOrderById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);

        }

        [HttpPut]
        [Route("update-order")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] OrderRequest request)
        {
            var newOrd = await _orderService.ChangeOrder(id, request);
            return Ok(newOrd);
        }



    }
}
