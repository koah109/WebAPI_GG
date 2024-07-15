using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLBH.Data;
using QLBH.DTO;
using QLBH.Interface;
using QLBH.Models;
using QLBH.Service;
using System.Reflection.Metadata.Ecma335;

namespace QLBH.Controllers
{
    public class AdminController : ControllerBase
    {
        private readonly IProduct _service;
        public AdminController(IProduct productService)
        {
            _service = productService; 
        }
        

        #region Customer
        /*        [HttpGet ("{GetListCustomer}")]
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

                    var result = new BaseResultPagingResponse<Customer>();
                    result.Status = 200;
                    result.Message = "Get ok";
                    result.Page = request.Page;
                    result.Total = 0;
                    result.Items = customers;

                    return Ok(result);
                }*/


        /*        [HttpDelete("{DeleteCustomer}")]
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
                }*/

        #endregion


        #region Product

        [HttpGet]
        [Route("SearchProduct")]
        public IActionResult getListProd(ProductDTO request)
        {
            var prod = _service.getList(request);
            var result = new BaseResultPagingResponse<Product>();
            result.Status = 200;
            result.Message = "Get ok";
            result.Page = request.Page;
            result.Total = 0;
            result.Items = prod.Result;
            return Ok(result);
        }

        /*[HttpPost]
        [Route("{PostProduct}")]
        public IActionResult postProd(Product product)
        {
            //_context.Product.Add(product);
            //_context.SaveChanges();
            return CreatedAtAction(nameof(postProd), new { id = product.PROD_CODE }, product);
        }

        [HttpPut]
        [Route("{UpdateProduct}")]
        public IActionResult putProd(int id, Product product)
        {
            if (id != product.PROD_CODE)
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
        }*/

        /*        [HttpDelete("{DeleteProduct}")]
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
                }*/

        #endregion

        #region Orders
        //[HttpGet("{GetListOrder}")]
        /*        public IActionResult getListOrders(int id)
                {
                    List<Orders> orders = _context.Orders.ToList();
                    if (id == null)
                    {
                        return NoContent();
                    }
                    return Ok(orders);
                }*/

        //[HttpDelete("{DeleteOrders}")]
        /*        public IActionResult deleteOrder(int id)
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
        #endregion

        /*public bool productExisted(int id)
        {
            return _context.Product.Any(e => e.PROD_CODE == id);
        }*/
    }
}
