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
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService department_Service)
        {
            _departmentService = department_Service;
        }

        [HttpGet]
        [Route("get-list-byid")]
        public async Task<IActionResult> GetDeptById(int id)
        {
            var dept = await _departmentService.GetDepartmentById(id);
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
            var dept = await _departmentService.PostDepartment(request);
            return Ok(dept);
        }

        [HttpPut]
        [Route("update-dept")]
        public async Task<IActionResult> PutDept(Department request)
        {
            var dept = await _departmentService.UpdateDepartment(request);
            return Ok(dept);
        }


        [HttpDelete]
        [Route("delete-byid")]
        public async Task<IActionResult> DeleteDept(int id)
        {
            var dept = await _departmentService.DeleteDepartment(id);
            return Ok(dept);
        }
    }
}
