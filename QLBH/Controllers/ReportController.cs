

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
        private readonly IReport Report_Service;
        public ReportController(IReport report)
        {
            Report_Service = report;
        }

        [HttpGet]
        [Route("get-report")]
        public async Task<IActionResult> GetReports(int request)
        {
            var rp = await Report_Service.GetReport(request);
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
