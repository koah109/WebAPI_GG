using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLBH.Data;
using QLBH.DTO;
using QLBH.Interface;
using QLBH.Models;
using QLBH.Models.Response;
using QLBH.Service;
using System.Reflection.Metadata.Ecma335;

namespace QLBH.Controllers
{
    public class AdminController : ControllerBase
    {
        private readonly IProduct Product_service;
        public AdminController(IProduct productService)
        {
            Product_service = productService; 
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
            var prod = Product_service.getList(request);
            var result = new BaseResultPagingResponse<Product>();
            result.Status = 200;
            result.Message = "Get ok";
            result.Page = 0;
            result.Total = 0;
            result.Items = prod.Result;
            return Ok(result);
        }

        [HttpGet]
        [Route("GetProduct")]

        public async Task<IActionResult> GetById(int id)
        {
            var order = await Product_service.getProd(id);
            var result = new BaseResultPagingResponse<Product>();
            result.Status = 200;
            result.Message = "Get ok";
            result.Page = 0;
            result.Total = 0;
            result.Items = order;
            return Ok(result);
        }

        [HttpPost]
        [Route("PostProduct")]
        public async Task<IActionResult> postProd(ProductDTO products)
        {
            /*if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }*/

            var product = await Product_service.PostProdById(products);
            return CreatedAtAction(nameof(GetById), new { id =product.PROD_CODE }, product);
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<IActionResult> putProd(Product products)
        {
            var product = await Product_service.PutProductById(products);
            return Ok(product);
        }

        [HttpDelete]
        [Route ("ProductDelete")]
        public async Task<IActionResult> deleteProd(int products)
        {
            var product = await Product_service.DeleteProductById(products);
            return Ok(product);
        }

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
