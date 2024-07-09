using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLBH.Data;
using QLBH.Models;

namespace QLBH.Controllers
{
    public class OrdersController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public OrdersController(ApplicationDBContext context)
        {
            _context = context;
        }

        #region
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orders>>> GetOrders()
        {
            return await _context.Orders.Include(o=>o.Order_no).ToListAsync();
        }

        [HttpGet ("{Order_no}")]
        public async Task<ActionResult<Orders>> GetOrder(int Order_no)
        {
            var order = await _context.Orders.FindAsync(Order_no);

            return order;
        }
        #endregion


        #region HttpPost
        [HttpPost ("{Order_no}")]
        public async Task<ActionResult<Orders>> PostOrder(Orders orders)
        {
            var order = _context.Orders.Add(orders);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Orders),new {orders_no=orders.Order_no}, orders);
        }
        #endregion

        #region HttpPut

        [HttpPut ("{Order_no}")]
        public async Task<IActionResult> PutOrder(int order_no,Orders orders)
        {
            if (order_no != orders.Order_no)
            {
                return BadRequest();
            }
            _context.Entry(orders).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExist(order_no))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }
        #endregion

        #region HttpDelete
        [HttpDelete ("{Order_no}")]
        public async Task<IActionResult> DeleteOrder(int Order_no)
        {
            var order = _context.Orders.FindAsync(Order_no);
            if (order == null)
            {
                return NotFound();
            }
            _context.Remove(order);
            await _context.SaveChangesAsync();
            return NoContent();
        } 
        #endregion
        public bool OrderExist(int Order_no)
        {
            return _context.Orders.Any(e=>e.Order_no == Order_no);
        }
    }
}
