using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLBH.Data;
using QLBH.DTO;
using QLBH.Interface;
using QLBH.Models;

namespace QLBH.Controllers
{
    public class HomeController : ControllerBase
    {
        private readonly IProduct _service;
        public HomeController(IProduct productService)
        {
            _service = productService;
        }

        [HttpGet]
        [Route("GetLisProduct")]
        public IActionResult getListProducts(Product product)
        {
            var prod = _service.getProd(product);
            var result = new BaseResultPagingResponse<Product>();
            result.Status = 200;
            result.Message = "Get ok";
            result.Page = 0;
            result.Total = 0;
            result.Items = prod.Result;
            return Ok(result);

        }

        /*[HttpGet]
        [Route("GetDetailProduct")]
        public IActionResult getDetailProduct(int id)
        {

            var prod = _context.Product
                .Where(n => n.PROD_CODE == id)
                .Include(n => n.PROD_NAME)
                .Include(n => n.UNITPRICE)
                .Include(n => n.STOCK_QTY)
                .FirstOrDefaultAsync().Result;
            return Ok(prod);
        }*/

        /*[HttpPost]
        [Route("{OrderProduct}")]
        public IActionResult orderProduct(Orders order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return CreatedAtAction(nameof(getDetailProduct), new { id = order.Order_no }, order);
        }*/

        /*[HttpDelete]
        [Route("{DeleteOrder}")]
        public IActionResult deleteOrder(int id)
        {
            Orders orders = _context.Orders.Where(n => n.Order_no == id).Include(n => n.Order_date).FirstOrDefaultAsync().Result;
            if (orders != null)
            {
                _context.Orders.Remove(orders);
                _context.SaveChanges();
                return Ok(orders);
            }
            return NoContent();
        }*/

        [HttpGet]
        [Route("{GetBill}")]
        public IActionResult getBills(Bill bill)
        {

            return null;
        }


    }
}
