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
        private readonly ICustomerService _customerService;// _customerService
        public CustomerController( ICustomerService customerService)
        {
            _customerService = customerService;
        }


        [HttpGet]
        [Route("list-cust")]
        public async Task<IActionResult> CustByID()
        {
            var cust = await _customerService.GetCustomer();
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
            var product = await _customerService.PostCust(request);
            return Ok(product);
        }

        [HttpPut]
        [Route("update-customer")]
        public async Task<IActionResult> UpdateCustomer(int id,CustomerRequest response)
        {
            var cust = await _customerService.PutCust(id,response);
            return Ok(cust);
        }


        [HttpDelete]
        [Route("delete-customer")]
        public async Task<IActionResult> DelCust(int id)
        {
            var cust = await _customerService.DeleteCus(id);
            return Ok(cust);
        }


        

    }
}
