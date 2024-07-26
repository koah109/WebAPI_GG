using Microsoft.AspNetCore.Mvc;
using QLBH.Interface;
using QLBH.Models;
using QLBH.Models.Entities;
using QLBH.Models.Request;
using QLBH.Models.Response;
using QLBH.Service;

namespace QLBH.Controllers
{
    [Route("api/department")]
    public class DepartmentController:ControllerBase
    {
        private readonly IDepartmentService Department_Service;
        public DepartmentController(IDepartmentService department_Service)
        {
            Department_Service = department_Service;
        }

        [HttpGet]
        [Route("get-list-byid")]
        public async Task<IActionResult> GetDeptById(int id)
        {
            var dept = await Department_Service.GetDepartmentById(id);
            var result = new BaseResultPagingResponse<Department>();
            result.Status = 200;
            result.Message = "Get ok";
            result.Page = 0;
            result.Total = 0;
            result.Items = dept;
            return Ok(result);
        }


        [HttpPost]
        [Route("post-new")]
        public async Task<IActionResult> PostDept([FromBody] DepartmentRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var dept = await Department_Service.PostDepartment(request);
            return CreatedAtAction(nameof(GetDeptById), new { id = dept.DEPT_CODE }, dept);
        }

        [HttpPut]
        [Route("update-dept")]
        public async Task<IActionResult> PutDept([FromBody] Department request)
        {
            var dept = await Department_Service.UpdateDepartment(request);
            return Ok(dept);
        }


        [HttpDelete]
        [Route("delete-byid")]
        public async Task<IActionResult> DeleteDept(int id)
        {
            var dept = await Department_Service.DeleteDepartment(id);
            return Ok(dept);
        }
    }
}
