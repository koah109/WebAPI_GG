using Microsoft.AspNetCore.Mvc;
using QLBH.Data;
using QLBH.Interface;
using QLBH.Models.Response;
using QLBH.Models;
using QLBH.Service;
using Azure.Core;
using QLBH.DTO;

namespace QLBH.Controllers
{
    [Route("api/employee")]
    public class EmployeeController:ControllerBase
    {
        private readonly IEmployeeService Emp_Service;
        public EmployeeController(IEmployeeService emp_Service)
        {
            Emp_Service = emp_Service;
        }

        [HttpGet]
        [Route("get-list-employee")]
        public async Task<IActionResult> GetEmpById(int id)
        {
            var emp = await Emp_Service.GetEmployee(id);
            var result = new BaseResultPagingResponse<Employee>();
            result.Status = 200;
            result.Message = "Get ok";
            result.Page = 0;
            result.Total = 0;
            result.Items = emp;
            return Ok(result);
        }

        [HttpPost]
        [Route("post-employee")]
        public async Task<IActionResult> PostEmployee([FromBody] EmployeeRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var emp = await Emp_Service.PostEmployee(request);
            return CreatedAtAction(nameof(GetEmpById), new { id = emp.EMP_CODE  }, emp);
        }



        [HttpDelete]
        [Route("delete-employee")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var emp = await Emp_Service.DeleteEmployee(id);
            return Ok(emp);
        }
    }
}
