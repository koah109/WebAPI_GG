using Microsoft.AspNetCore.Mvc;
using QLBH.Interface;
using QLBH.Models.Response;
using QLBH.Models;
using QLBH.DTO;
using Azure.Core;

namespace QLBH.Controllers
{
    [Route("api/customer")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService Customer_service;
        public CustomerController( ICustomerService customerService)
        {
            Customer_service = customerService;
        }

        [HttpGet]
        [Route("list-customer")]
        public async Task<IActionResult> GetListCust(int id)
        {
            var cust = await Customer_service.GetCustomer(id);
            var result = new BaseResultPagingResponse<Customer>();
            result.Status = 200;
            result.Message = "Get ok";
            result.Page = 0;
            result.Total = 0;
            result.Items = cust;
            return Ok(result);
        }

        [HttpGet]
        [Route("list-cust/{id}")]
        public async Task<IActionResult> CustByID(int id)
        {
            var cust = await Customer_service.GetCustomer(id);
            var result = new BaseResultPagingResponse<Customer>();
            result.Status = 200;
            result.Message = "Get ok";
            result.Page = 0;
            result.Total = 0;
            result.Items = cust;
            return Ok(result);
        }

        [HttpPost]
        [Route("post-customer")]
        public async Task<IActionResult> RegisterCust([FromBody] CustomerRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await Customer_service.PostCust(request);
            return CreatedAtAction(nameof(CustByID), new { id = product.CUST_CODE }, product);
        }

        [HttpPut]
        [Route("update-customer")]
        public async Task<IActionResult> UpdateCustomer(Customer response)
        {
            var cust = await Customer_service.PutCust(response);
            return Ok(cust);
        }


        [HttpDelete]
        [Route("delete-customer")]
        public async Task<IActionResult> DelCust(int id)
        {
            var cust = await Customer_service.DeleteCus(id);
            return Ok(cust);
        }


        

    }
}
