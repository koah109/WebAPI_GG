

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using QLBH.Interface;
using QLBH.Models.Request;
using QLBH.Models.Response;

namespace QLBH.Controllers
{
    [Route("api/report")]
    public class ReportController:ControllerBase
    {
        private readonly IReport _reportService;
        public ReportController(IReport report)
        {
            _reportService = report;
        }

        [HttpGet]
        [Route("get-report")]
        public async Task<IActionResult> GetReports(int request)
        {
            var rp = await _reportService.GetReport(request);
            var result = new BaseResultPagingResponse<ReportRequest>();
            result.Status = 200;
            result.Message = "Get ok";
            result.Page = 0;
            result.Total = 0;
            result.Items = rp;
            return  Ok(result);
        }


    }
}
