﻿using Microsoft.AspNetCore.Mvc;
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
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService emp_Service)
        {
            _employeeService = emp_Service;
        }

        [HttpGet]
        [Route("get-list-employee")]
        public async Task<IActionResult> GetEmpById(int id)
        {
            var emp = await _employeeService.GetEmployee(id);
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

            var emp = await _employeeService.PostEmployee(request);
            return Ok(emp);
        }

        [HttpPut]
        [Route("update-employee")]
        public async Task<IActionResult> PutEmployee(Employee request)
        {
            var cust = await _employeeService.UpdateEmployee(request);
            return Ok(cust);
        }



        [HttpDelete]
        [Route("delete-employee")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var emp = await _employeeService.DeleteEmployee(id);
            return Ok(emp);
        }
    }
}
