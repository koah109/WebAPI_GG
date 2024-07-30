
using Microsoft.AspNetCore.Mvc;
using QLBH.Interface;
using QLBH.Models.Response;
using QLBH.Models;
using QLBH.Service;
using QLBH.Models.Entities;
using QLBH.Models.Request;


namespace QLBH.Controllers
{
    [Route("api/warehouse")]
    public class WarehouseController : ControllerBase
    { 
        private readonly IWarehouseService Warehouse_Service;
        public WarehouseController(IWarehouseService warehouseService)
        {
            Warehouse_Service = warehouseService;
        }

        [HttpGet]
        [Route("get-warehouse/{id}")]
        public async Task<IActionResult> GetWareHouse(int id)
        {
            var wh = await Warehouse_Service.GetWHById(id);
            var result = new BaseResultPagingResponse<Warehouse>();
            result.Status = 200;
            result.Message = "Get ok";
            result.Page = 0;
            result.Total = 0;
            result.Items = wh;
            return Ok(result);
        }

        [HttpPost]
        [Route("post-warehouse")]
        public async Task<IActionResult> PostWareHouse([FromBody] WarehouseRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var wh = await Warehouse_Service.PostWH(request);
            return CreatedAtAction(nameof(GetWareHouse), new { id = wh.WH_CODE }, wh);
        }

        [HttpDelete]
        [Route("delete-warehouse")]
        public async Task<IActionResult> DeleteWarehouse(int id)
        {
            var wh = await Warehouse_Service.DeleteWH(id);
            return Ok(wh);
        }
    }
}
