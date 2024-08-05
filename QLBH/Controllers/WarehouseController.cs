
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
        private readonly IWarehouseService _warehouseService;
        public WarehouseController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        [HttpGet]
        [Route("get-warehouse/{id}")]
        public async Task<IActionResult> GetWareHouse(int id)
        {
            var wh = await _warehouseService.GetWHById(id);
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

            var wh = await _warehouseService.PostWH(request);
            return Ok(wh);
        }


        [HttpPut]
        [Route("update-warehouse")]
        public async Task<IActionResult> PutWareHouse(Warehouse request)
        {
            var wh = await _warehouseService.UpdateWH(request);
            return Ok(wh);
        }

        [HttpDelete]
        [Route("delete-warehouse")]
        public async Task<IActionResult> DeleteWarehouse(int id)
        {
            var wh = await _warehouseService.DeleteWH(id);
            return Ok(wh);
        }


    }
}
