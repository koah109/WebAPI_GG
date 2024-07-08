using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLBH.Data;
using QLBH.Models;
using System.Collections;

namespace QLBH.Controllers
{
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public ProductController(ApplicationDBContext context)
        {
            _context = context;
        }

        #region HttpGet
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        [HttpGet ("{Prod_code}")]
        public async Task<ActionResult<Product>> GetProduct(int Prod_code)
        {
            var product = await _context.Products.FindAsync(Prod_code);

            if (product == null)
            {
                return NotFound();
            }
            return product;
        }
        #endregion

        #region HttpPost
        [HttpPost ("{Prod_code}")]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProduct), new { id = product.Prod_name }, product);
        }
        #endregion



        #region HttpPut
        [HttpPut ("{Prod_code}")]
        public async Task<IActionResult> PutProduct(int Prod_code, Product product)
        {
            if (Prod_code != product.Prod_code)
            {
                return BadRequest();
            }    
            _context.Entry(product).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!ProductExist(Prod_code))
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
        [HttpDelete ("{Prod_code}")]
        public async Task<IActionResult> ProductDelete(int Prod_code)
        {
            var product = await _context.Products.FindAsync(Prod_code);
            if (product == null)
            {
                return NotFound();
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        #endregion
        private bool ProductExist(int Prod_code)
        {
            return _context.Products.Any(e => e.Prod_code == Prod_code);
        }
    }
}
