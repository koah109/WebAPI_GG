using Microsoft.AspNetCore.Mvc;
using QLBH.DTO;
using QLBH.Interface;
using QLBH.Models;
using QLBH.Models.Response;
using QLBH.Service;

namespace QLBH.Controllers
{
    [Route("API/Register")]
    public class Register:ControllerBase
    {
        private readonly ICustomer Customer_service;
        public Register(ICustomer customerService)
        {
            Customer_service = customerService;
        }
        [HttpPost]
        [Route("PostCustomer")]
        public async Task<IActionResult> RegisterCust(CustomerDTO customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await Customer_service.PostCust(customer);
            return CreatedAtAction(nameof(CustByID), new { id = product.CUST_CODE }, product);
        }

        [HttpGet]
        [Route("CustById")]
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

    }
}
