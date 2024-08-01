using Microsoft.EntityFrameworkCore;
using QLBH.Data;
using QLBH.Interface;
using QLBH.Models;
using QLBH.Models.Request;

namespace QLBH.Service
{
    public class ReportService:IReport
    {
        private readonly ApplicationDBContext _context;
        public ReportService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<ReportRequest>> GetReport(int id)
        {
            //Lấy TotalSales từ OrderDetail
            var orderDetailsSum = _context.ORDER_DETAILS
            .GroupBy(od => new { od.Orders.ORDER_DATE.Month, od.Orders.ORDER_DATE.Year })
            .Select(g => new
            {
                g.Key.Month,
                g.Key.Year,
                TotalSales = g.Sum(od=>od.QUANTITY)
            });

            //Lấy TotalOrders từ Orders
            var ordersCount = _context.ORDERS
            .Where(o => o.ORDER_DATE.Year == id)
            .GroupBy(o => new { o.ORDER_DATE.Month, o.ORDER_DATE.Year })
            .Select(g => new
            {
                g.Key.Month,
                g.Key.Year,
                TotalOrders = g.Count()
            });

            //Gọi lại 2 biến của OrderDetail và Orders để đưa thông tin vào Report
            var report = await orderDetailsSum
            .Join(ordersCount,
                  odSum => new { odSum.Month, odSum.Year },
                  oCount => new { oCount.Month, oCount.Year },
                  (odSum, oCount) => new ReportRequest
                  {
                      MONTH = odSum.Month,
                      YEAR = odSum.Year,
                      TOTALSALES = odSum.TotalSales,
                      TOTALORDERS = oCount.TotalOrders
                  })
            .OrderBy(r => r.MONTH)
            .ToListAsync();

            return report;
        }
    }
}
