using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLBH.Data;
using QLBH.DTO;
using QLBH.Models;

namespace QLBH.Controllers
{
    public class AdminController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public AdminController (ApplicationDBContext context)
        {
            _context = context;
        }

        #region Customer
        [HttpGet ("{GetListCustomer}")]
        public IActionResult getListCust(CustomerDTO request)
        {
            List<Customer> customers = _context.Customer.ToList();
            if (request != null)
            {
                if (request.searchValue != null)
                {
                    customers = customers.Where(n=>n.Cust_name.Contains(request.searchValue)).ToList();
                }
            }
            return Ok(customers);
        }


        [HttpDelete("{DeleteCustomer}")]
        public IActionResult deleteCust(Customer customer)
        {
            var cust = _context.Customer.FindAsync(customer);
            if (cust == null)
            {
                return NotFound();
            }
            _context.Customer.Remove(customer);
            _context.SaveChanges();
            return NoContent();
        }

        #endregion


        #region Product

        [HttpGet("{GetListProduct}")]
        public IActionResult getListProd(SearchDTO request)
        {
            List<Product> prod = _context.Product.ToList();
            if (request != null)
            {
                if (request.searchValue != null)
                {
                    prod = prod.Where(n => n.Prod_name.Contains(request.searchValue)).ToList();
                }
            }
            return Ok(prod);
        }

        [HttpPost("{PostProduct}")]
        public IActionResult postProd(Product product)
        {
            _context.Product.Add(product);
            _context.SaveChanges();
            return CreatedAtAction(nameof(getListProd), new { id = product.Prod_code }, product);
        }

        [HttpPut("{UpdateProduct}")]
        public IActionResult putProd(int id, Product product)
        {
            if (id != product.Prod_code)
            {
                return BadRequest();
            }
            _context.Entry(product).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!productExisted(id))
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

        [HttpDelete("{DeleteProduct}")]
        public IActionResult deleteProd(int id)
        {
            Product product = _context.Product.Include(n=>n.Prod_code).Include(n=>n.Prod_name).FirstOrDefault(n=>n.Prod_code == id);
            if (product != null)
            {
                _context.Product.Remove(product);
                _context.SaveChanges();
                return Ok(product);
            }
            else
            {
                return NotFound();
            }
        }

        #endregion

        public bool productExisted(int id)
        {
            return _context.Product.Any(e=>e.Prod_code == id);
        }
    }
}
