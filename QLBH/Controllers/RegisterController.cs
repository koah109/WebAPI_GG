using Microsoft.AspNetCore.Mvc;
using QLBH.Data;
using QLBH.Models;

namespace QLBH.Controllers
{
    public class RegisterController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public RegisterController(ApplicationDBContext context)
        {
            _context = context;
        }


        [HttpPost("{Register}")]
        public IActionResult Register (Customer customer)
        {
            Customer accountDB = _context.Customer.FirstOrDefault(n=>n.Username== customer.Username);
            if (accountDB != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Username Existed");
            }
            else
            {
                
                customer.Update_date = DateTime.Now;
                _context.Customer.Add(customer);
                _context.SaveChanges();
                return Ok(customer);
            }

        }
    }
}
