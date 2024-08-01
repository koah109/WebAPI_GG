using QLBH.Models.Request;

namespace QLBH.Interface
{
    public interface IReport
    {
        Task<List<ReportRequest>> GetReport(int id);
    }
}
