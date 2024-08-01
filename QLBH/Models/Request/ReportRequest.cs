using QLBH.DTO;
using QLBH.Models.Response;

namespace QLBH.Models.Request
{
    public class ReportRequest
    {
        public int MONTH { get; set; }

        public int YEAR { get; set; }

        public decimal TOTALORDERS {  get; set; }

        public decimal TOTALSALES { get; set; }
    }
}
