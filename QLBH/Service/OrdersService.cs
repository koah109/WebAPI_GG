using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLBH.Data;
using QLBH.DTO;
using QLBH.Interface;
using QLBH.Models;
using System.Reflection.Metadata.Ecma335;

namespace QLBH.Service
{
    public class OrdersService: IOrdersService
    {
        private readonly ApplicationDBContext _context;
        public OrdersService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<ORDER_DETAILS> PostOrders(OrderRequest request, OrderDetailRequest drequest)
        {

            var order = new Orders
            {
                DEPT_CODE = 1,
                CUST_CODE = 6,
                EMP_CODE = 4,
                WH_CODE = 1,
                CMP_TAX = 15,
                SLIP_COMMENT = "Quá tốt",
            };
            var orders = new ORDER_DETAILS
            {
                PROD_CODE = drequest.PROD_CODE,
                //ORDER_NO = order.ORDER_NO,
            };
            _context.ORDERS.Add(order);
            _context.ORDER_DETAILS.Add(orders);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Có lỗi xảy ra khi lưu đơn hàng", ex);
            }
            return orders;


        }

        public async Task<List<Orders>> GetOrderById(int id)
        {
            return await _context.ORDERS.ToListAsync();
        }


        public async  Task<Orders> DeleteOrderById(int id)
        {
            Orders orders = await _context.ORDERS.Where(n => n.ORDER_NO == id).FirstOrDefaultAsync();
            if (orders != null)
            {
                _context.ORDERS.Remove(orders);
                await _context.SaveChangesAsync();
            }
            return orders;

        }
    }
}
