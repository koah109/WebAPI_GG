using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLBH.Data;
using QLBH.Models;

namespace QLBH.Controllers
{
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public CustomerController(ApplicationDBContext context)
        {
            _context = context;
        }
        #region HttpGet
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        [HttpGet("{Cust_code}")]
        public async Task<ActionResult<Customer>> GetCustomer()
        {
            var customer = await _context.Customers.FindAsync();
            if (customer == null) {
                return NotFound();
            }
            return customer;
        }
        #endregion


        #region HttpPost
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCustomer), new { id = customer.Cust_code }, customer);
        }

        #endregion

        #region HttpPut
        [HttpPut("{Cust_code}")]
        public async Task<IActionResult> PutCustomer(int  id, Customer customer)
        {
            if (id != customer.Cust_code)
            {
                return BadRequest();
            }
            _context.Entry(customer).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!CustomerExist(id)) 
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
        [HttpDelete("{Cust_code}")]

        public async Task<IActionResult> DeleteCustomer()
        {
            var customer = await _context.Customers.FindAsync();
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        #endregion

        private bool CustomerExist(int id)
        {
            return _context.Customers.Any(e=>e.Cust_code== id);
        }
    }
}
